/* Signals it's like events in C# */
using strange.extensions.signal.impl;

public class AppStartSignal : Signal { }

public class GameInputSignal : Signal<int> { }

public class TetriminoPieceSignal : Signal { }