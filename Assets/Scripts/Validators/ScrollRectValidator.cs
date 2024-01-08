#if UNITY_EDITOR
using Sirenix.OdinInspector.Editor.Validation;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

[assembly: RegisterValidator(typeof(ScrollRectValidator))]

public class ScrollRectValidator : RootObjectValidator<ScrollRect>
{
    protected override void Validate(ValidationResult result)
    {
        var toBeChecked = this.Object;
        if (toBeChecked.scrollSensitivity != 30)
        {
            toBeChecked.scrollSensitivity = 30;
			result.AddWarning($"The scrollSensitivity of the {toBeChecked.name} has been fixed to 30");
		}
	}
}
#endif
