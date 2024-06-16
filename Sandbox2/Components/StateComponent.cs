using System.Reflection;

namespace RayLibTemplate.Sandbox2.Components
{
	internal class StateComponent : IComponent
	{
		public IState CurrentState { get; private set; }

		public StateComponent(IState initialState)
		{
			CurrentState = initialState;
		}

		public void ChangeState(IState newState)
		{
			CurrentState = newState;


			// TODO: Debug
			// Attempt to get a property named "StateName" from the newState object
			PropertyInfo nameProperty = newState.GetType().GetProperty("Name", BindingFlags.Public | BindingFlags.Instance);

			if (nameProperty != null && nameProperty.PropertyType == typeof(string))
			{
				// If the property exists and is of type string, get its value
				string stateNameValue = (string)nameProperty.GetValue(newState);

				// Log the value of the "StateName" property
				Console.WriteLine($"State name: {stateNameValue}");
			}
			else
			{
				// If the property does not exist or is not of type string, log a default message
				Console.WriteLine("The state does not have a 'StateName' property or it is not of type string.");
			}
		}
	}
}
