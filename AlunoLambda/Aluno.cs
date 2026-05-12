using Amazon.DynamoDBv2.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlunoLambda
{
    [DynamoDBTable("alunos")]
    public class Aluno
    {
        [DynamoDBHashKey("id")]
        public int? Id { get; set; }
        [DynamoDBProperty("nome")]
        public string? Nome { get; set; }
        [DynamoDBProperty("sobrenome")]
        public string? Sobrenome { get; set; }
        [DynamoDBProperty("classe")]
        public int? Classe { get; set; }
    }
}
