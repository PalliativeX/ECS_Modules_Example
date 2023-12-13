using Dreamcore.Core;

namespace Dreamcore.Quests
{
	public static class QuestContextExtensions
	{
		public static QuestEntity Create(this QuestContext quest)
		{
			var entity = quest.CreateEntity();
			entity.AddId(IdGenerator.GetNext());
			return entity;
		}
	}
}