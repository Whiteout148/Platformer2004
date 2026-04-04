using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int MaxDefenceUlt;
    [SerializeField] private int MinDefenceUlt;
    [SerializeField] private Patroller _patroller;
    [SerializeField] private Persecutter _persecutter;
    [SerializeField] private PlaceDetector _detector;
    [SerializeField] private AnimationShower _shower;
    [SerializeField] private Health _health;
    [SerializeField] private Defencer _defencer;
    [SerializeField] private Attacker _attacker;
    [SerializeField] private Stunner _stunner;
    [SerializeField] private GameObject _WarningSign;

    private int _currentUlt;
    private int _currentMaxUlt;
    private BehaviourState _state;
    private Player _target;

    private void Start()
    {
        _currentMaxUlt = UnityEngine.Random.Range(MinDefenceUlt, MaxDefenceUlt + 1);

        _currentUlt = 0; 
        _state = BehaviourState.Normal;

        _patroller.StartPatroling();
    }

    private void OnEnable()
    {
        _detector.ComeOnPlace += OnDetectPlayer;
        _detector.GetOutOnPlace += OnPlayerLeave;
        _persecutter.ReadyToAttack += _shower.PlayAttack;
        _persecutter.StartMoveing += _shower.PlayMove;
        _persecutter.StopMoveing += _shower.StopPlayMove;
        _patroller.StartMoveing += _shower.PlayMove;
        _patroller.StopMoveing += _shower.StopPlayMove;
        _health.Dead += _patroller.StopPatroling;
        _health.Dead += _persecutter.StopPersecuting;
        _health.Dead += OnDie;
        _health.Dead += _shower.PlayDie;
        _defencer.StartingDefence += _shower.PlayDefence;
        _defencer.EndDefence += _shower.StopPlayDefence;
        _stunner.StartedStunn += _shower.OnStartStunn;
        _stunner.EndStunn += _shower.OnEndStunn;
        _attacker.Attacked += AddUlt;
    }

    private void OnDisable()
    {
        _health.Dead -= OnDie;
        _health.Dead -= _shower.PlayDie;
    }
    
    private void OnDie()
    {
        _detector.ComeOnPlace -= OnDetectPlayer;
        _detector.GetOutOnPlace -= OnPlayerLeave;
        _persecutter.ReadyToAttack -= _shower.PlayAttack;
        _persecutter.StartMoveing -= _shower.PlayMove;
        _persecutter.StopMoveing -= _shower.StopPlayMove;
        _patroller.StartMoveing -= _shower.PlayMove;
        _patroller.StopMoveing -= _shower.StopPlayMove;
        _health.Dead -= _patroller.StopPatroling;
        _health.Dead -= _persecutter.StopPersecuting;
        _defencer.StartingDefence -= _shower.PlayDefence;
        _defencer.EndDefence -= _shower.StopPlayDefence;
        _stunner.StartedStunn -= _shower.OnStartStunn;
        _stunner.EndStunn -= _shower.OnEndStunn;
        _attacker.Attacked -= AddUlt;

        if (transform.TryGetComponent(out BoxCollider2D collider))
        {
            collider.enabled = false;
        }
        
        if (transform.TryGetComponent(out Rigidbody2D rigidbody))
        {
            Destroy(rigidbody);
        }
    }

    private void OnDetectPlayer(Player player)
    {
        _state = BehaviourState.Persecution;
        _target = player;

        _patroller.StopPatroling();
        _persecutter.StartPersecuting(_target);
    }

    private void OnPlayerLeave()
    {
        _persecutter.StopPersecuting();
        _target = null;

        _state = BehaviourState.Normal;
        _patroller.StartPatroling();
    }

    private void AddUlt()
    {
        if (_currentUlt == _currentMaxUlt - 1)
        {
            _WarningSign.SetActive(true);
        }

        if (_currentUlt >= _currentMaxUlt)
        {
            _defencer.StartDefence();
            _currentUlt = 0;
            _WarningSign.SetActive(false);

            _currentMaxUlt = Random.Range(MinDefenceUlt, MaxDefenceUlt + 1);
        }
        else
        {
            _currentUlt++;
        }
    }
}

