# Leapfrog

A learning project in WPF technologies and recent frameworks, such as:

- WPF / C# 6.0
- MVP (Presenters, Application composition, separation of concern)
- MVVM (Commands, ViewModels, DataBinding)
- Messaging

Frameworks
- CommunityToolkit.MVVM
- Microsoft.Extension.DependencyInjection

(with little emphasize on styling and tests)

![GitHub Logo](/leapfrog.png)

## Application buildup

*MainPresenter* is responsible for the overall orchestration of the application layout, whereas *NavigationPresenter* and *BrowserPresenter* is responsible for the *Navigation View* and the *Browser View*.

- This pattern is also referred to as *MVPVM* (MVP+MVVM).
- A presenter knows only 1 view, but could know other presenters. The Presenter is responsible for orchestrating the View.
- Views communicate their actions via events through either databindings to a ViewModel (such as a *Command*), or also *EventHandlers* to *Presenters* where necessary, such as *+=ViewLoaded*).
- No view logic,. A view does not have any references, or know anything about the world. View's code behind is minimized to a bare minimum.
- *CommunityToolkit.MVVM.WeakReferenceMessenger* is used to raise and listen to cross-View events, such as communication between the Navigation View and the Browser View. This is especially seen in the "Back" and "Forward" buttons, who will enable/disable depending on the possibility to navigate backward or forward.

## Todo
This learning projects does not cover the use of *Models* through *Services/Repository*. However, on a general principle, the *Presenter* should be the one who fetch data sources. *Models* are fed to the *ViewModel* (perhaps trimmed or manipulated) by the *Presenter*, who is responsible for setting the *DataContext* (read: the *ViewModel*) to the *View*. This help reduce the *ViewModels* responsibility to only concern data, and not also dependencies and other logic.
