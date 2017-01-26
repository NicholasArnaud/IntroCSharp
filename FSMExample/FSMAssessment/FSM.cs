using System;
using System.Collections.Generic;
using System.IO;

namespace FSMAssessment
{
    class FSM
    {
        public enum State
        {
            INIT = 0,
            WALK = 1,
            RUN = 2,
            SHOUT = 3,
            EXIT = 9999,
        }

        public State state;

        public void AddFunction(Delegate function)
        {

            onEnter += function as Handler;
        }

        string name;
        public Handler onEnter;
        public Handler onExit;

/*
 * public class Monster : MonoBehaviour {
 
    public enum State {
        Crawl,
        Walk,
        Die,
    }
 
    public State state;
 
    IEnumerator CrawlState () {
        Debug.Log("Crawl: Enter");
        while (state == State.Crawl) {
            yield return 0;
        }
        Debug.Log("Crawl: Exit");
        NextState();
    }
 
    IEnumerator WalkState () {
        Debug.Log("Walk: Enter");
        while (state == State.Walk) {
            yield return 0;
        }
        Debug.Log("Walk: Exit");
        NextState();
    }
 
    IEnumerator DieState () {
        Debug.Log("Die: Enter");
        while (state == State.Die) {
            yield return 0;
        }
        Debug.Log("Die: Exit");
    }
 
    void Start () {
        NextState();
    }
}
*/
    }
}