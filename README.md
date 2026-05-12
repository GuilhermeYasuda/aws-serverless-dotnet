# 🚀 AWS Serverless .NET Demo

Este repositório é um guia prático para o desenvolvimento de aplicações **Serverless** utilizando o ecossistema **.NET** na **Amazon Web Services (AWS)**. O projeto demonstra como construir CRUDs escaláveis utilizando as melhores práticas de nuvem.

## 🛠️ Tecnologias Utilizadas

*   **Linguagem:** .NET 10 (Migrado da versão original .NET 6)
*   **Compute:** AWS Lambda
*   **API Management:** Amazon API Gateway (HTTP API)
*   **Database:** Amazon DynamoDB
*   **IaC/Deployment:** AWS CloudFormation / SAM (Serverless Application Model)

## 📁 Estrutura do Projeto

O repositório está dividido em exemplos práticos:
*   **`HelloLambda`**: Exemplo introdutório para entender o ciclo de vida de uma função Lambda e integração básica com API Gateway.
*   **`StudentLambda`**: Implementação de um CRUD completo (Get All, Get by ID, Create) integrado ao DynamoDB.

## 🚀 Como Executar

### Pré-requisitos
*   [.NET 10 SDK](https://microsoft.com) instalado.
*   [AWS CLI](https://amazon.com) configurado.
*   [AWS SAM CLI](https://amazon.com) para deploy.

### Passos
1.  **Clone o repositório:** `git clone https://github.com/GuilhermeYasuda/aws-serverless-dotnet.git`
2.  **Restaure as dependências:** `dotnet restore`
3.  **Deploy (via SAM):** `sam build && sam deploy --guided`

## 🌟 Créditos e Evolução

Este projeto foi inicialmente baseado no tutorial de **Mukesh Murugan**:
👉 [Amazon API Gateway with .NET - AWS Lambda & DynamoDB Integrations](https://codewithmukesh.com)

**Principais melhorias realizadas neste fork:**
*   **Atualização de Framework:** Migração do projeto original (.NET 6) para o **.NET 10**, aproveitando as últimas melhorias de performance e sintaxe.
*   **Otimização de Dependências:** Atualização dos pacotes NuGet da AWS SDK para versões compatíveis com o ambiente mais recente.

## 📈 Evolução Técnica: .NET 6 vs .NET 10

A migração trouxe melhorias significativas para o ambiente Serverless:


| Recurso | .NET 6 (Original) | .NET 10 (Atual) | Impacto no Serverless |
| :--- | :--- | :--- | :--- |
| **Cold Start** | Padrão | Otimizado com **Native AOT** | Execução quase instantânea |
| **JSON Serialization** | `Newtonsoft.Json` | `System.Text.Json` | Menor uso de memória e CPU |
| **Tamanho do Pacote** | Maior (JIT) | Reduzido (Trimming/AOT) | Deploy mais rápido |
| **Linguagem** | C# 10 | **C# 14** | Código mais moderno e limpo |
| **Minimal APIs** | Estágio Inicial | Alta Performance | Menor overhead no API Gateway |

---
Feito por [Guilherme Yasuda]
