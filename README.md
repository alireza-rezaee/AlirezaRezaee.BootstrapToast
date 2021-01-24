# BootstrapToast
A .NET library and actually a [TagHelper](https://docs.microsoft.com/en-us/aspnet/core/mvc/views/tag-helpers/intro) for displaying notifications built with C#


### How to use
Insert `@addTagHelper *, AlirezaRezaee.BootstrapToastTagHelper` to view, then use toast tag as shown below:

```
<toast message="your message here"
    type="ToastType.Information"
    title="The message title"
    date-time="DateTime.Now"
    animation="true"
    autohide="true"
    delay="500"
    has-bootstrap-icon-font="true"></toast>
```

As before, we use the Bootstrap [`show`](https://getbootstrap.com/docs/5.0/components/toasts/#javascript-behavior) to Initialize toasts via JavaScript.
```
window.addEventListener('load', () => {
    [].slice.call(document.querySelectorAll('.toast')).forEach(toastEl => new bootstrap.Toast(toastEl).show());
    timeago.render(document.querySelectorAll('.toast time'));
});
```


### Attributes:

| Name                    | Data type       |            |
|-------------------------|-----------------|------------|
| message                 | System.String   | *required* |
| title                   | System.String   | optional   |
| date-time               | System.DateTime | optional   |
| animation               | System.Boolean  | optional   |
| autohide                | System.Boolean  | optional   |
| delay                   | System.Int32    | optional   |
| has-bootstrap-icon-font | System.Boolean  | optional   |



### Dependency

* .Net standard (>=2.0)
* [Twitter Bootstrap](https://getbootstrap.com/) 5.x
* [Twitter Bootstrap Icons](https://icons.getbootstrap.com/) (optional)
* [timeago.js](https://timeago.org/) (optional)
