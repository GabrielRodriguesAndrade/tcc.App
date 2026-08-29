# Política de segurança

- Não envie APKs, símbolos de depuração, pastas `.vs`, `bin`, `obj` ou arquivos `*.user` para o Git.
- Nunca coloque senhas, tokens, connection strings ou chaves de assinatura dentro do aplicativo.
- Credenciais de API devem ser entregues por um back-end autenticado. Um aplicativo móvel não consegue manter um segredo embutido de forma confiável.
- Não registre senhas, dados pessoais, placas, telefones ou respostas completas de API em logs.
- Limpe campos sensíveis assim que o fluxo de autenticação ou cadastro terminar.
- Use somente HTTPS com validação normal de certificado ao integrar o aplicativo a uma API.

O histórico anterior continha artefatos de compilação e símbolos. Eles foram removidos para reduzir a possibilidade de exposição de metadados e configurações geradas.
