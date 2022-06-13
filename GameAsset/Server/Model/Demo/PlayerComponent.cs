using System.Collections.Generic;

namespace ET
{
	/// <summary>
	/// 该服玩家合集
	/// </summary>
	[ComponentOf(typeof(Scene))]
	[ChildType(typeof(Player))]
	public class PlayerComponent : Entity, IAwake, IDestroy
	{
		public readonly Dictionary<long, Player> idPlayers = new Dictionary<long, Player>();
	}
}