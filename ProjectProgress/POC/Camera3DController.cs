using Godot;

public partial class Camera3DController : Camera3D
{
	public override void _Ready()
	{
		Input.MouseMode = Input.MouseModeEnum.Captured;
	}

	public override void _Input(InputEvent @event)
	{
		if (@event is InputEventMouseMotion mouse)
		{
			RotationDegrees += new Vector3(
				-mouse.Relative.Y * 0.1f,
				-mouse.Relative.X * 0.1f,
				0
			);
		}
	}
}
