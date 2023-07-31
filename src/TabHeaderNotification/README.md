#TabView Header Notification Badge

This demo uses conditional logic, with a custom HeaderItem `ControlTemplate` to only show notification badges on specific tab headers.

![image](https://github.com/LanceMcCarthy/CustomMauiExamples/assets/3520532/767b61fe-26c6-4f24-ad8e-c93947d04296)

The key takeaway is we combine information from both the `TabViewHeaderItem` context, and the `Label.Text` value to determine if the Label should be visible for that specific tab.