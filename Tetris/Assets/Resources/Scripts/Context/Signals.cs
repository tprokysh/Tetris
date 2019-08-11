/* Signals it's like events in C# */
using strange.extensions.signal.impl;
using UnityEngine;

public class SpawnTetrominoSignal : Signal { }

public class TetriminoPlaceSignal : Signal<GameObject> { }
