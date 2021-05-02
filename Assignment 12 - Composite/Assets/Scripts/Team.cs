/*
 * Benjamin Schuster
 * Assignment 12 - Composite
 * The concrete team, which is a container item
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Team : TurnComponent
{
    public List<TurnComponent> _turnComponents = new List<TurnComponent>();
    public Material _teamMaterial;
    public float _delay;

    public override string GetName()
    {
        return _name;
    }

    public override Roles GetRole()
    {
        return _role;
    }

    public override void NextTurn()
    {
        StartCoroutine(IterateTeamMembers(_turnComponents));
    }

    //private void IterateTeamMembers(IEnumerable<TurnComponent> turnComponent)
    //{
    //    IEnumerator<TurnComponent> enumerator = turnComponent.GetEnumerator();
    //    _readyForNext = true;

    //    while(enumerator.MoveNext() )
    //    {
    //        TurnComponent component = enumerator.Current;
    //        component.NextTurn();

    //        _readyForNext = false;
    //        StartCoroutine(TurnDelay());
    //    }
    //}

    public override void Add(TurnComponent member)
    {
        _turnComponents.Add(member);
    }
    public override void Remove(TurnComponent member)
    {
        if(_turnComponents != null && _turnComponents.Contains(member))
            _turnComponents.Remove(member);
    }

    // iterate through and apply the team color
    private void ApplyTeamColor(IEnumerable<TurnComponent> turnComponent)
    {
        IEnumerator<TurnComponent> enumerator = turnComponent.GetEnumerator();

        while(enumerator.MoveNext())
        {
            GameObject component =  enumerator.Current.gameObject;

            Renderer temp = component.GetComponent<Renderer>();
            if (temp != null)
                temp.material = _teamMaterial;
        }
    }

    private void Start()
    {
        ApplyTeamColor(_turnComponents);
    }

    IEnumerator IterateTeamMembers(IEnumerable<TurnComponent> turnComponent)
    {
        IEnumerator<TurnComponent> enumerator = turnComponent.GetEnumerator();

        while (enumerator.MoveNext())
        {
            yield return new WaitForSeconds(_delay);

            TurnComponent component = enumerator.Current;
            component.NextTurn();

            yield return null;
        }

        Debug.Log("---" + GetName() + "'s turn has ended---");
    }
}
