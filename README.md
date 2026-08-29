# IngaDrive — aplicativo móvel

Aplicativo Android desenvolvido como parte de um Trabalho de Conclusão de Curso (TCC) para apoiar profissionais que atuam em estacionamentos de eventos. O app reúne oportunidades de trabalho, candidaturas, agenda de eventos e o acompanhamento das vagas e dos veículos durante uma operação.

> O projeto está em fase de protótipo. As telas e os principais fluxos de navegação estão implementados, mas parte dos dados ainda é simulada localmente e a integração com o back-end permanece pendente.

## Funcionalidades

- tela inicial com acesso ao cadastro e ao login;
- calendário para consulta de eventos;
- listagem de eventos agendados;
- listagem de oportunidades com local, horário, remuneração e vagas restantes;
- confirmação de candidatura para uma oportunidade;
- acompanhamento de um evento ativo;
- visualização das vagas e dos veículos associados;
- detalhe de um veículo observado com contador regressivo.

## Tecnologias

- C#;
- Xamarin.Forms 5;
- Xamarin.Essentials;
- .NET Standard 2.0;
- Xamarin.Android;
- Android 5.0 ou superior (API 21+);
- Syncfusion Xamarin SfCalendar.

## Estrutura do projeto

```text
ingaDrive/
├── ingaDrive.sln
├── ingaDrive/                 # Projeto compartilhado Xamarin.Forms
│   ├── Models/                # Modelos usados pelas telas
│   ├── Controller/            # Ponto reservado para integração de dados
│   ├── MainPage.xaml          # Agenda, eventos e oportunidades
│   ├── ConfirmarCandidatura.xaml
│   ├── EventoAtivo.xaml
│   └── CarroObervado.xaml
└── ingaDrive.Android/         # Projeto e recursos específicos do Android
```

## Como executar

### Pré-requisitos

- Windows com uma versão do Visual Studio compatível com Xamarin;
- ferramentas do Xamarin.Android e Android SDK instaladas;
- emulador Android configurado ou aparelho com depuração USB habilitada.

### Passos

1. Clone o repositório:

   ```bash
   git clone https://github.com/GabrielRodriguesAndrade/tcc.App.git
   ```

2. Abra `ingaDrive/ingaDrive.sln` no Visual Studio.
3. Restaure os pacotes NuGet da solução.
4. Defina `ingaDrive.Android` como projeto de inicialização.
5. Selecione um emulador ou aparelho Android.
6. Compile e execute a solução.

## Estado atual e próximos passos

Atualmente, login, cadastro, eventos, vagas e candidaturas representam o fluxo visual do produto, mas não persistem dados. A classe `MySQLCon` também está reservada para uma futura integração.

Evoluções sugeridas:

- conectar o aplicativo ao back-end;
- implementar autenticação e cadastro reais;
- substituir os dados simulados por informações da API;
- persistir candidaturas e operações do estacionamento;
- adicionar testes e tratamento de falhas de rede;
- migrar o projeto para .NET MAUI em uma futura modernização.

## Projeto relacionado

O módulo web de administração e relatórios está em [tcc_web](https://github.com/GabrielRodriguesAndrade/tcc_web).

## Segurança

Artefatos de compilação, configurações locais e pacotes gerados não fazem parte do versionamento. O aplicativo não deve armazenar senhas, chaves de API nem credenciais de banco; uma futura integração deverá usar uma API HTTPS autenticada, mantendo os segredos somente no servidor. Consulte [SECURITY.md](SECURITY.md) para as diretrizes do projeto.
