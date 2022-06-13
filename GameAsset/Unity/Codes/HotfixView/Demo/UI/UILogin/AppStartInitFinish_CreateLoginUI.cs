

namespace ET
{
	public class AppStartInitFinish_CreateLoginUI: AEvent<EventType.AppStartInitFinish>
	{
		protected override void Run(EventType.AppStartInitFinish args)
		{
			// 收到事件,创建UI
			UIHelper.Create(args.ZoneScene, UIType.UILogin, UILayer.Mid).Coroutine();
		}
	}
}
