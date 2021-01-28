using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DataEase
{
    public class RelationshipExport
    {
        public List<Relationship> Export(string filePath)
        {
            int recordLength = 226;

            var rawData = this.ReadFile(filePath);

            var relationshipRecords = new List<Relationship>();

            var recordData = new List<byte>(recordLength);

            for (int i = 0; i < rawData.Length; i++)
            {
                recordData.Add(rawData[i]);

                if (recordData.Count == recordLength)
                {
                   relationshipRecords.Add(this.ParseRelationshipRecord(recordData));

                    recordData = new List<byte>(recordLength);
                }
            }

            return relationshipRecords;
        }

        private Relationship ParseRelationshipRecord(List<byte> recordData)
        {
            var relationship = new Relationship();

            // Skip first 4 bytes, they are not used.
            int index = 4;

            // Form 1 and Form 2 names are 29 bytes.
            relationship.PrimaryTableName = this.ParseString(recordData, index, 29);

            index += 29;

            relationship.ForeignTableName = this.ParseString(recordData, index, 29);

            index += 29;

            // 2 bytes after form 2 name, is Form 1 modify type and Form 2 modify type.
            relationship.PrimaryTableModifyType = (RelationshipFormModifyType)recordData[index];
            index += 1;

            relationship.ForeignTableModifyType = (RelationshipFormModifyType)recordData[index];
            index += 1;

            // Each field name is 20 bytes.
            relationship.FirstFieldFilter.PrimaryFieldName = this.ParseString(recordData, index, 20);
            index += 20;

            relationship.FirstFieldFilter.ForeignFieldName = this.ParseString(recordData, index, 20);
            index += 20;

            relationship.SecondFieldFilter.PrimaryFieldName = this.ParseString(recordData, index, 20);
            index += 20;

            relationship.SecondFieldFilter.ForeignFieldName = this.ParseString(recordData, index, 20);
            index += 20;

            relationship.ThridFieldFilter.PrimaryFieldName = this.ParseString(recordData, index, 20);
            index += 20;

            relationship.ThridFieldFilter.ForeignFieldName = this.ParseString(recordData, index, 20);
            index += 20;

            // Each relationship name is 20 bytes.
            relationship.PrimaryRelationshipName = this.ParseString(recordData, index, 20);
            index += 20;

            relationship.ForeignRelationshipName = this.ParseString(recordData, index, 20);
            index += 20;

            // Last 2 bytes are for form 1 and form 2 security level.
            relationship.PrimaryTableSecurity = (RelationshipSecurityLevel)recordData[index];
            index += 1;

            relationship.ForeignTableSecurity = (RelationshipSecurityLevel)recordData[index];

            return relationship;
        }

        public byte[] ReadFile(string filePath)
        {
            return File.ReadAllBytes(filePath);
        }

        private string ParseString(List<byte> data, int skip, int take)
        {
            return ASCIIEncoding.ASCII.GetString(data.Skip(skip).Take(take).ToArray());
        }
    }
}
