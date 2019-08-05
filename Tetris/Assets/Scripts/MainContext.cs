using System;
using strange.extensions.command.impl;
using UnityEngine;

public class MainContext : SignalContext
{
	public MainContext(MonoBehaviour view) /* Call base(SignalContext) constructor */
		: base(view)
	{

	}

	protected override void mapBindings() /* Bind signals with commands (...Once() - just one time */
	{
		base.mapBindings();

		injectionBinder.Bind<IExecuter>().To<CoroutineExecuter>().ToSingleton();
		commandBinder.Bind<AppStartSignal>().InSequence().To<ShowLoadingCommand>().To<AppStartCommand>().To<HideLoadingCommand>().Once(); /* InSequence - posledovatelnost' */ /* Can swap commands without many moves, wow! */
	}
}
