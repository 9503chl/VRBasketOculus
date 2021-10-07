using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateController : MonoBehaviour
{
    [SerializeField] GameObject gameReady;  // GameReady 게임 오브젝트 참조
    [SerializeField] RemainTimer timer;     // RemainTimer 컴포넌트 참조
    [SerializeField] GameObject gameStart;  // GameStart 게임 오브젝트 참조
    [SerializeField] GameObject gameOver; // GameOver 게임 오브젝트 참조 
    [SerializeField] GameObject result;     // Result 게임 오브젝트 참조
    [SerializeField] GameObject player;     // PlayerGun 게임 오브젝트 참조
    [SerializeField] GameObject GoalDae;
    [SerializeField] GameObject Button;
    [SerializeField] GameObject Hands; //게임끝난후 발사하는 공위치
    [SerializeField] GameObject Rim;
    [SerializeField] GameObject Defender;
    [SerializeField] GameObject ThreeptsAlarm;
    [SerializeField] GameObject NextStage;
    [SerializeField] AudioSource ReadyAudioSource;
    [SerializeField] AudioSource GamePlayAudioSource;
    [SerializeField] AudioSource GameOverAudioSource;
    [SerializeField] AudioSource ThreeptsAudioSource;


    // 스테이트 베이스 클래스
    abstract class BaseState
    {
        public GameStateController Controller { get; set; }

        public enum StateAction
        {
            STATE_ACTION_WAIT,
            STATE_ACTION_NEXT
        }

        public BaseState(GameStateController c) { Controller = c; }

        public virtual void OnEnter() { }
        public virtual StateAction OnUpdate() { return StateAction.STATE_ACTION_NEXT; }
        public virtual void OnExit() { }
    }

    // 게임 시작 준비 스테이트
    class ReadyState : BaseState
    {
        float timer;

        public ReadyState(GameStateController c) : base(c) { }
        public override void OnEnter()
        {
            // ready 문자열을 표시
            Controller.gameReady.SetActive(true);
            Controller.player.SetActive(false);
            Controller.GoalDae.SetActive(false);
            Controller.Rim.SetActive(false);
            Controller.ThreeptsAlarm.SetActive(false);
            Controller.ReadyAudioSource.Play();
            Controller.Hands.SetActive(false);
            Controller.Button.SetActive(false);
        }
        public override StateAction OnUpdate()
        {
            timer += Time.deltaTime;
            // 5초 후에 다음으로
            if (timer > 5.0f)
            {
                return StateAction.STATE_ACTION_NEXT;
            }
            return StateAction.STATE_ACTION_WAIT;
        }
        public override void OnExit()
        {
            // ready 문자열을 숨김
            Controller.gameReady.SetActive(false);
        }
    }

    // 게임 시작 표시 스테이트
    class StartState : BaseState
    {
        float timer;

        public StartState(GameStateController c) : base(c) { }
        public override void OnEnter()
        {
            // 타이머를 표시
            Controller.timer.gameObject.SetActive(true);
            Controller.player.SetActive(true);
            Controller.GoalDae.SetActive(true);
            Controller.Rim.SetActive(true);
            Controller.Defender.SetActive(true);
            // start 문자열을 표시
            Controller.gameStart.SetActive(true);

            // player를 표시
            Controller.player.SetActive(true);

         
        }
        public override StateAction OnUpdate()
        {
            timer += Time.deltaTime;
            // 1초 후에 다음으로
            if (timer > 1.0f)
            {
                return StateAction.STATE_ACTION_NEXT;
            }
            return StateAction.STATE_ACTION_WAIT;
        }
        public override void OnExit()
        {
            // Start 문자열을 숨김
            Controller.gameStart.SetActive(false);
        }
    }

    // 게임 중 스테이트
    class PlayingState : BaseState
    {
        float timer; bool truth = true;
        public PlayingState(GameStateController c) : base(c) { }
        public override void OnEnter()
        {
            Controller.GamePlayAudioSource.Play();
        }

        public override StateAction OnUpdate()
        {
            timer += Time.deltaTime;
            // 타이머가 종료하면 게임 오버
            if (!Controller.timer.IsCountingDown())
            {
                return StateAction.
                  
             STATE_ACTION_NEXT;
            }
            if(timer >= 43.7f && truth)
            {
                Controller.ThreeptsAlarm.SetActive(true);
                Controller.ThreeptsAudioSource.Play();
                truth = false;
            }
            return StateAction.STATE_ACTION_WAIT;
        }

        public override void OnExit()
        {
            // 플레이어를 숨김
            Controller.player.SetActive(false);
            Controller.ThreeptsAlarm.SetActive(false);
            Controller.GamePlayAudioSource.Stop();
        }
    }

    // 게임 오버 표시 스테이트
    class GameOverState : BaseState
    {
        float timer;
        public GameOverState(GameStateController c) : base(c) { }
        public override void OnEnter()
        {
            // 게임 오버를 표시
            Controller.gameOver.SetActive(true);
            Controller.GoalDae.SetActive(false);
            Controller.Rim.SetActive(false);
            Controller.ThreeptsAlarm.SetActive(false);
            Controller.Defender.SetActive(false);
            Controller.GameOverAudioSource.Play();
           
        }
        public override StateAction OnUpdate()
        {
            timer += Time.deltaTime;
            // 2초 후에 다음으로
            if (timer > 2.0f)
            {
                return StateAction.STATE_ACTION_NEXT;
            }
            return StateAction.STATE_ACTION_WAIT;
        }
        public override void OnExit()
        {
            // 게임 오버를 숨김
            Controller.gameOver.SetActive(false);
        }
    }

    // 결과 표시 스테이트
    class ResultState : BaseState
    {
        public ResultState(GameStateController c) : base(c) { }
        public override void OnEnter()
        {
            // 결과 표시
            Controller.result.SetActive(true);
            Controller.Button.SetActive(true);
            Controller.Hands.SetActive(true);
            float Total = GameObject.Find("Score").GetComponent<Score>().Points;
            if(Total >= 20.0f)
            {
                Controller.NextStage.SetActive(true);
            }
        }
        public override StateAction OnUpdate() { return StateAction.STATE_ACTION_WAIT; }
    }

    // 게임의 상태 리스트
    List<BaseState> state;

    // 현재의 게임 상태
    int currentState;

    void Start()
    {
        // 게임의 상태를 순서대로 등록
        state = new List<BaseState> {
            new ReadyState(this),
            new StartState(this),
            new PlayingState(this),
            new GameOverState(this),
            new ResultState(this),
        };
        // 처음 상태의 시작 처리
        state[currentState].OnEnter();
    }

    void Update()
    {
        //  상태를 갱신
        var stateAction = state[currentState].OnUpdate();

        // 다음 상태로 전환할지 판정
        if (stateAction == BaseState.StateAction.STATE_ACTION_NEXT)
        {
            // 상태 종료 처리
            state[currentState].OnExit();
            // 다음의 상태로
            ++currentState;
            // 상태 시작 처리
            state[currentState].OnEnter();
        }
    }
}