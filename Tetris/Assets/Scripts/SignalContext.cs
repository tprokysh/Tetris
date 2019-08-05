using strange.extensions.command.api;
using strange.extensions.command.impl;
using strange.extensions.context.api;
using strange.extensions.context.impl;
using UnityEngine;

public class SignalContext : MVCSContext
{
	public SignalContext(MonoBehaviour contextView)
		: base(contextView, ContextStartupFlags.MANUAL_MAPPING)
	{
	}

	protected override void addCoreComponents() /* Use signals for commands */
	{
		base.addCoreComponents();

		injectionBinder.Unbind<ICommandBinder>();
		injectionBinder.Bind<ICommandBinder>().To<SignalCommandBinder>().ToSingleton();
	}
		
	public override void Launch() /* Call <AppStartSignal> as program start point */
	{
		base.Launch();

		var startSignal = injectionBinder.GetInstance<AppStartSignal>();
		startSignal.AddListener(() => Debug.Log("AddListener")); /* Subscribe and call, without unsubscripe */
		startSignal.AddOnce(() => Debug.Log("AddOnce")); /* Subsrcibe, call and unsubscripe */
		startSignal.Dispatch();
	}

	protected override void mapBindings() /* Namespaces for sripts */
	{
		base.mapBindings();
//		implicitBinder.ScanForAnnotatedClasses(new string[] { "" });
	}
}