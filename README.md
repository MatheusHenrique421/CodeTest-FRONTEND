# CodeTest-FRONTEND

#### Projeto de estudos voltado ao aprimoramento de habilidades e testes com novas tecnologias no desenvolvimento front-end.  
### Tem como foco principal a integração com APIs, uso de bibliotecas de notificação, autenticação e organização modular do código.
### Além de C# e Razor, o projeto também utiliza JavaScript para customizações de validação, interações visuais e efeitos dinâmicos. O layout é construído com Bootstrap para garantir responsividade e uma experiência visual consistente.

Este projeto utiliza dois sistemas de notificação para melhorar a experiência do usuário e fornecer feedbacks claros e visuais:
---
## 🔔 Toast Notifications (NToastNotify com Toastr)

O `NToastNotify` está integrado ao projeto com o tema `Toastr`, sendo utilizado para mensagens rápidas e não bloqueantes como:

- Sucesso em ações (ex: login bem-sucedido)
- Erros de validação
- Avisos ou informações

### ✅ Funcionalidades implementadas:
- Título personalizado via extensão `AddCustomToast`
- Posição no topo direito
- Barra de progresso visível
- Prevenção de mensagens duplicadas

#### 📦 Exemplo de uso:

```csharp
_toastNotification.AddCustomToast(ToastType.Error, "Falha no login", "Usuário ou senha inválidos!");
