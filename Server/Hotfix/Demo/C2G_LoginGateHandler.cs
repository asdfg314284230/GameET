using System;


namespace ET
{
	[MessageHandler]
	[FriendClass(typeof(SessionPlayerComponent))]
	public class C2G_LoginGateHandler : AMRpcHandler<C2G_LoginGate, G2C_LoginGate>
	{
		protected override async ETTask Run(Session session, C2G_LoginGate request, G2C_LoginGate response, Action reply)
		{
			Scene scene = session.DomainScene();
			string account = scene.GetComponent<GateSessionKeyComponent>().Get(request.Key);
			if (account == null)
			{
				response.Error = ErrorCore.ERR_ConnectGateKeyError;
				response.Message = "Gate key验证失败!";
				reply();
				return;
			}
			
			session.RemoveComponent<SessionAcceptTimeoutComponent>();

			// 在服务器玩家列表合集中添加一个玩家
			PlayerComponent playerComponent = scene.GetComponent<PlayerComponent>();
			Player player = playerComponent.AddChild<Player, string>(account);
			playerComponent.Add(player);

			session.AddComponent<SessionPlayerComponent>().PlayerId = player.Id;
			session.AddComponent<MailBoxComponent, MailboxType>(MailboxType.GateSession);



			// DOTO:自此该服玩家创建成功
			// 下发PlayerId;
			response.PlayerId = player.Id;
			reply();
			await ETTask.CompletedTask;
		}
	}
}