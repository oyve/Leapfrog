# Leapfrog

A learning project in WPF technologies and recent frameworks, such as:

- WPF / C# 6.0
- MVP
- MVVM
- Presenters, ViewModels, Views, Application composition
- Messaging
- Todo: Make Presenter fetch domain models from a service and feed to ViewModel

Frameworks
- CommunityToolkit.MVVM
- Microsoft.Extension.DependencyInjection

(with little emphasize on styling and tests)

![GitHub Logo](/leapfrog.png)

## Application buildup

*MainPresenter* is responsible for the overall orchestration of the application layout, whereas *NavigationPresenter* and *BrowserPresenter* is responsible for the *Navigation View* and the *Browser View*.

- A presenter knows 1 view. A view does not have any references, or know anything about the world.
- Views communicate their actions via events through either databindings to a ViewModel (such as a Command), or also EventHandlers to Presenters where necessary, such as +=ViewLoaded)
- No view logic, "dumb view". View's code behind is minimized to a bare minimum, the Presenter is responsible for orchestrating the View
- CommunityToolkit.MVVM.WeakReferenceMessenger is used to raise and listen to cross-View events, such as communication between the Navigation View and the Browser View

## Todo
This learning projects does not cover the use of Models through Services/Repository, however, on a general principle, the Presenter should be the one who fetches a data source. Models will be fed to the ViewModel (perhaps trimmed or manipulated) via the Presenter, who is responsible for setting the DataContext to the View.
