# Different monaco c# completion experiments

1. `bicep` - from [here](https://github.com/anthony-c-martin/bicep/tree/antmarti/experiment%2Fmonaco_lsp) (also ref [issue](https://github.com/OmniSharp/csharp-language-server-protocol/issues/456)) uses [monaco-languageclient](https://github.com/TypeFox/monaco-languageclient), so it turns monaco into a real language server client, on the backend wasm with omnisharp and custom provider for bicep. (.NET 5)

   `cd src/playground && npm i && npm run start`

2. `MonacoRoslynCompletionProvider` - uses regular `monaco.languages.registerCompletionItemProvider` and sends async request to a self hosted wasm project. (.NET 6)

   `cd Sample/wwwwrot && npm i && cd .. && dotnet run`

3. `BlazorPnPTest` - runs PnP SDK code inside wasm, based on [Runny](https://github.com/Suchiman/Runny) and modified for .NET 5.

   Build it in VS, then Ctrl+F5, then in code update token (only SharePoint access token works, not MS Graph) and site url and click Run.
