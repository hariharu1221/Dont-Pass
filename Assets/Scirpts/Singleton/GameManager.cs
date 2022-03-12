using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GameManager : Singleton<GameManager>
{
    private Charater OneChar;
    private Charater TwoChar;
    private Charater NowChar;

    private GameObject linecolPrefab;
    private GameObject linecolGroup;
    private GameObject linePrefab;
    private GameObject lineGroup;
    private GameObject boxcolPrefab;
    private GameObject boxcolGroup;
    private GameObject hitboxPrefab;
    private GameObject hitboxGroup;
    private GameObject charPrefab;
    private GameObject enemyPrefab;
    private GameObject canvas;

    private FixedPatternList patternString;
    private List<FixedPattern> patternList;

    private List<LineCol> line = new List<LineCol>();
    private List<BoxCol> hitbox = new List<BoxCol>();

    private int hp;
    private int gold;
    private int enemyCount;
    private float score;
    private float allMult;
    private bool isGame;

    private Button StartButton;
    private Button SwitchButton;

    public List<LineCol> Line { get { return line; } }
    public float AllMult { get { return allMult; } set { allMult = value; } }

    private void Awake()
    {
        SetInstance();
        VariableSet();
    }

    private void VariableSet()
    {
        linecolPrefab = Resources.Load<GameObject>("Prefabs/LineCol");
        linecolGroup = GameObject.Find("LineColGroup");

        linePrefab = Resources.Load<GameObject>("Prefabs/Line");
        lineGroup = GameObject.Find("LineGroup");

        boxcolPrefab = Resources.Load<GameObject>("Prefabs/BoxCol");
        boxcolGroup = GameObject.Find("BoxColGroup");

        hitboxPrefab = Resources.Load<GameObject>("Prefabs/HitBox");
        hitboxGroup = GameObject.Find("HitBoxGroup");

        enemyPrefab = Resources.Load<GameObject>("Prefabs/Enemy");
        charPrefab = Resources.Load<GameObject>("Prefabs/Charater");

        patternString = Resources.Load<FixedPatternList>("SO/FixedPatternList");
        patternList = patternString.ReadAll();

        canvas = GameObject.Find("Canvas");

        StartButton = GameObject.Find("StartButton").GetComponent<Button>();
        StartButton.onClick.AddListener(() => StartGame());

        SwitchButton = GameObject.Find("SwitchButton").GetComponent<Button>();
        SwitchButton.onClick.AddListener(() => Switch());

        GameObject.Find("AddButton").GetComponent<Button>().onClick.AddListener(() => AddLine()); //지우기
        isGame = false;
    }

    private void Update()
    {
        InGameUpdate();
    }

    private void InGameUpdate()
    {
        if (!isGame) return;
        GetKey();
        Debug.Log(score);
    }

    private void GetKey()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            StartCoroutine(PressScreen(EnemyDir.R, EnemyState.Normal));
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            StartCoroutine(PressScreen(EnemyDir.L, EnemyState.Normal));
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Switch();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            UseSkill();
        }
    }

    private bool GetDoubleKey(KeyCode one, KeyCode two)
    {
        if  ((Input.GetKey(one) && Input.GetKeyDown(two))
          || (Input.GetKeyDown(one) && Input.GetKey(two))
          || (Input.GetKeyDown(one) && Input.GetKeyDown(two))) 
        {
            return true;
        }
        return false;
    }

    private void StartGame() //게임 시작
    {
        if (isGame) return;
        isGame = true;
        Set();
        StartCoroutine(InGame());
    }

    private void Set() //게임 시작시 세팅
    {
        var one = Instantiate(charPrefab);
        var two = Instantiate(charPrefab);
        OneChar = GetChar.getchar(0, one);
        TwoChar = GetChar.getchar(1, two);

        NowChar = OneChar;
        hp = OneChar.Hp + TwoChar.Hp;
        gold = 0;
        score = 0;
        allMult = 1;

        normalMiss = false;
        bothMiss = false;

        OneChar.Passive();
        TwoChar.Passive();

        AddLine();
        SetHitBox();
    }

    private IEnumerator InGame() //인게임 코루틴 
    {
        //게임 시작 이펙트
        while(hp > 0)
        {
            if (enemyCount >= 200 * Mathf.Pow(line.Count, 2)) // 1 4 9 16 25 36
            {
                AddLine();
            }
            yield return new WaitForFixedUpdate();
        }
        //게임 종료 이펙트
        EndGame();
        yield return null;
    }

    private IEnumerator InLine(LineCol line) //라인마다 패턴 대입
    {
        yield return new WaitForSeconds(1f);
        while(hp > 0)
        {
            int rand = Random.Range(0, patternList.Count);
            yield return PlayPattern(patternList[rand], line);
            yield return new WaitForFixedUpdate();
        }
    }

    private IEnumerator PlayPattern(FixedPattern pattern, LineCol line) //패턴 재생
    {
        foreach(SecondEnemy se in pattern.EnemyList)
        {
            SpawnEnemy(se.enemy, line);
            yield return new WaitForSeconds(se.second);
        }
    }

    bool normalMiss;
    bool bothMiss;
    private IEnumerator PressScreen(EnemyDir dir, EnemyState state) //화면 눌렀을 때
    {
        if (bothMiss) yield break;
        if (normalMiss && state == EnemyState.Normal) yield break;

        foreach(BoxCol i in hitbox)
            i.AttackEnemy(dir, state);

        yield return new WaitForSeconds(0.025f);

        int sum = GetScoreWithCount();

        if (sum == 0)
        {
            StartCoroutine(PressMiss());
            yield break;
        }
        else if (state == EnemyState.BothTouch) //both타일 제거시 초기화
        {
            normalMiss = false;
            bothMiss = false;
        }
    }

    private IEnumerator PressMiss() //눌렀을 떄 아무것도 제거하지 못했을 경우
    {
        normalMiss = true;
        bothMiss = true;
        yield return new WaitForSeconds(0.3f);
        normalMiss = false;
        bothMiss = false;
    }

    private void SpawnEnemy(Enemy enemy, LineCol line) //적 생성
    {
        var n = Instantiate(enemyPrefab, line.gameObject.transform);
        var e = n.AddComponent<EnemyMono>();
        var enemyState = enemy;
        e.EnemyState = enemyState;

        SetEnemy(e, line);
        line.InEnemy(e);
    }

    private void SetEnemy(EnemyMono enemy, LineCol line) //스테이트에 맞는 적 정보 입력
    {
        var enemyState = enemy.EnemyState;

        if (enemyState.dir == EnemyDir.R)
        {
            enemy.transform.position = new Vector3(-8.7f, line.transform.position.y);
            //정방향
        }
        else if (enemyState.dir == EnemyDir.L)
        {
            enemy.transform.position = new Vector3(8.7f, line.transform.position.y);
            enemy.transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
            //반대방향
        }

        enemy.transform.localScale = Vector3.zero;
        DOTween.To(() => enemy.transform.localScale, x => enemy.transform.localScale = x, new Vector3(0.1f, 0.1f), 0.5f);
    }

    private int GetScoreWithCount()
    {
        int sum = 0;
        foreach (BoxCol i in hitbox)
        {
            i.StopAttack();
            i.PlusScore(ref score);
            sum += i.PlusCount(ref enemyCount);
        }
        return sum;
    }

    private void AddLine() //라인 추가
    {
        var lin = Instantiate(linePrefab, lineGroup.transform).GetComponent<Line>();
        var col = Instantiate(linecolPrefab, linecolGroup.transform).GetComponent<LineCol>();

        lin.name = "[ " + (line.Count + 1) + " ] 번째 라인";
        col.name = "[ " + (line.Count + 1) + " ] 번째 라인 콜리더";

        RectTransform rect = lin.Rect;
        rect.anchoredPosition = Vector3.zero;
        rect.sizeDelta = new Vector2(0, 5);

        col.transform.position = Vector3.zero;
        col.Line = lin;

        line.Add(col);

        SetLine();
        StartCoroutine(InLine(col));
    }

    private void SetLine() //라인 위치 조정
    {
        float time = 1;

        if (line.Count == 1)
        {
            RectTransform rect = line[0].Line.Rect;
            DOTween.To(() => rect.sizeDelta, x => rect.sizeDelta = x, new Vector2(1800, 5), time);
            return;
        }

        float y = 5f / (line.Count - 1f);
        for (int i = 0; i < line.Count; i++)
        {
            RectTransform rect = line[i].Line.Rect;
            Transform tran = line[i].transform;
            Vector3 pos;
            Vector3 rectPos;

            if (i == 0)
            {
                pos = new Vector3(0, -2.5f, 0);
                DOTween.To(() => tran.position, x => tran.position = x, pos, time);
                rectPos = Camera.main.WorldToScreenPoint(pos);
                DOTween.To(() => rect.transform.position, x => rect.transform.position = x, rectPos, time);
                continue;
            }

            pos = new Vector2(0, -2.5f + (y * i));
            DOTween.To(() => tran.position, x => tran.position = x, pos, time);
            rectPos = Camera.main.WorldToScreenPoint(pos);
            DOTween.To(() => rect.transform.position, x => rect.transform.position = x, rectPos, time);

            DOTween.To(() => rect.sizeDelta, x => rect.sizeDelta = x, new Vector2(1800, 5), time);
        }
    }

    private void DestroyBox()
    {
        foreach (BoxCol box in hitbox)
        {
            DOTween.To(() => box.Box.Rect.sizeDelta, x => box.Box.Rect.sizeDelta = x, new Vector2(box.Box.Rect.sizeDelta.x, 0), 1f);
            StartCoroutine(Utils.DelayDestroy(box.Box.gameObject, 1.5f));
            Destroy(box.gameObject);
        }
        hitbox.Clear();
    }

    private void SetHitBox()
    {
        List<BoxCol> list = new List<BoxCol>();
        foreach(Point p in NowChar.ColiderPos)
        {
            var box = Instantiate(hitboxPrefab, hitboxGroup.transform).GetComponent<HitBox>();
            var col = Instantiate(boxcolPrefab, boxcolGroup.transform);

            BoxCol n = col.GetComponent<BoxCol>();
            n.Col.size = new Vector2(p.x / 200, 10);
            n.transform.position = new Vector2(p.y, 0);
            //new Vector2((97 / 100) * p.y, 0);

            RectTransform rect = box.Rect;
            rect.sizeDelta = new Vector2(p.x, 0);
            rect.transform.position = Camera.main.WorldToScreenPoint(col.transform.position);
            DOTween.To(() => rect.sizeDelta, x => rect.sizeDelta = x, new Vector2(p.x, 700), 1f);

            n.Box = box;
            list.Add(n);
        }

        hitbox = list;
        SetScoreBonus();
    }

    private void SetScoreBonus()
    {
        foreach (var col in hitbox)
        {
            col.AllMult = allMult;
        }
    }

    private void DestroyLine() //게임 끝났을 때 타일 제거
    {
        foreach(var line in line)
        {
            DOTween.To(() => line.Line.Rect.sizeDelta, x => line.Line.Rect.sizeDelta = x, new Vector2(0, 5), 1f);
            StartCoroutine(Utils.DelayDestroy(line.Line.gameObject, 1.5f));
            Destroy(line.Col);
        }
        line.Clear();
    }

    private void EndGame() //게임 종료
    {
        if (!isGame) return;
        isGame = false;
        StopAllCoroutines();
        DestroyLine();
        DestroyBox();
    }

    private void Switch() //현재 캐릭터 스위치 1 to 2, 2 to 1
    {
        if (NowChar.GetType() == OneChar.GetType())
            NowChar = TwoChar;
        else if (NowChar.GetType() == TwoChar.GetType())
            NowChar = OneChar;

        DestroyBox();
        SetHitBox();
    } 

    private void UseSkill()
    {
        NowChar.UseSkill();
    }
}

//[인게임 추가할 것]
//왼쪽 오른쪽 치면 안되는거 두번치기 점수 보너스 투명한거 폭
//드래그로 스위치

//[스킬 목록]
//모든 라인 클리어 (점수 획득 가능)                               (쿨타임 30초) S Clear
//5초간 시야 축소 이후 라인클리어 20초간 점수 보너스 && 적이 커짐 (쿨타임 40초) S
//5초간 판정 범위 축소 이후 20초간 판정 범위가 전체로 변경        (쿨타임 40초) S
//10초간 판정 범위에 닿는 것 만으로 지움                          (쿨타임 30초) S
//스위치 시 10초 무적                                             (쿨타임 40초) S
//10% 확률로 적이 등장할 때 마다 적용 해당 적을 빨간 적으로 변경  (스킬 상시)   S
//랜덤 라인 속도 느려지기 && 점수 보너스                          (스킬 상시)   A
//10초간 판정 범위 확대 && 점수 보너스                            (쿨타임 20초) A
//랜덤 라인 5초간 제외하기                                        (쿨타임 10초) A
//5초 무적                                                        (쿨타임 30초) A
//한 라인을 제외한 다른 모든 라인 정지 && 점수 보너스             (쿨타임 25초) A
//모든 라인 속도 빨라짐 && 점수 보너스                            (스킬 상시)   B
//골드 보너스                                                     (스킬 상시)   B
//보호막 생성                                                     (쿨타임 15초) B
//랜덤 라인 클리어 (점수 획득 가능)                               (쿨타임 15초) B Clear
//점수 보너스                                                     (스킬 상시)   B Clear

//[상점에서 팔 것]
//배경
//

//[메인 UI 구성]
//상점
//스타트
//설정
//재화
//도전 과제
//스킬장착창