#region Copyright and License
// Copyright 2010..2017 Alexander Reinert
// 
// This file is part of the ARSoft.Tools.Net - C# DNS client/server and SPF Library (https://github.com/alexreinert/ARSoft.Tools.Net)
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
#endregion

using InspireSafe.Tools.Net.Dns.DnsRecord;

namespace InspireSafe.Tools.Net.Dns.DynamicUpdate
{
	/// <summary>
	///   Delete record action
	/// </summary>
	public class DeleteRecordUpdate : UpdateBase
	{
		/// <summary>
		///   Record that should be deleted
		/// </summary>
		public DnsRecordBase Record { get; }

		internal DeleteRecordUpdate() {}

		/// <summary>
		///   Creates a new instance of the DeleteRecordUpdate class
		/// </summary>
		/// <param name="name"> Name of the record that should be deleted </param>
		/// <param name="recordType"> Type of the record that should be deleted </param>
		public DeleteRecordUpdate(DomainName name, RecordType recordType)
			: base(name, recordType, RecordClass.Any, 0) {}

		/// <summary>
		///   Creates a new instance of the DeleteRecordUpdate class
		/// </summary>
		/// <param name="record"> Record that should be deleted </param>
		public DeleteRecordUpdate(DnsRecordBase record)
			: base(record.Name, record.RecordType, RecordClass.None, 0)
		{
			Record = record;
		}

		internal override void ParseRecordData(byte[] resultData, int startPosition, int length) {}

		internal override string RecordDataToString()
		{
			return Record?.RecordDataToString();
		}

		protected internal override int MaximumRecordDataLength => Record?.MaximumRecordDataLength ?? 0;

		protected internal override void EncodeRecordData(byte[] messageData, int offset, ref int currentPosition, Dictionary<DomainName, ushort> domainNames, bool useCanonical)
		{
			Record?.EncodeRecordData(messageData, offset, ref currentPosition, domainNames, useCanonical);
		}
	}
}