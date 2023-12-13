using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Dreamcore.Quests
{
	[Serializable]
	[HideLabel]
	public struct QuestGiverId : IEquatable<QuestGiverId>
	{
		public static QuestGiverId None = new QuestGiverId("");
		
		[LabelText("QuestGiverId")]
		[ValueDropdown("GetAllItemOptions", IsUniqueList = false)]
		[SerializeField] private string _value;
		
		public string Value => _value;
		
		public QuestGiverId(string value) => _value = value;

		public bool Equals(QuestGiverId other) => _value == other._value;

		public override bool Equals(object obj) => obj is QuestGiverId id && Equals(id);

		public override int GetHashCode() => _value.GetHashCode();

		public static explicit operator QuestGiverId(string value) => new QuestGiverId(value);

		public static implicit operator string(QuestGiverId id) => id._value;

		public static bool operator ==(QuestGiverId a, QuestGiverId b) => a._value == b._value;

		public static bool operator !=(QuestGiverId a, QuestGiverId b) => a._value != b._value;

		public override string ToString() => _value;
		
		private IEnumerable GetAllItemOptions()
		{
			var questGiverEntries = Resources.Load<QuestStorage>("Storages/QuestStorage");

			List<string> questGiverIds = new List<string>();
			foreach (var quest in questGiverEntries.Quests) 
				questGiverIds.Add(quest.QuestGiverId);

			return questGiverIds;
		}
	}
}