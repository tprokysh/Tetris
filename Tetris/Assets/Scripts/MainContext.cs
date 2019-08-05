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

		commandBinder.Bind<AppStartSignal>().To<AppStartCommand>().Once();
	}
}
