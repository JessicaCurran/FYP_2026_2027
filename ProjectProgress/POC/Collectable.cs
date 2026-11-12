using Godot;

public partial class Collectable : Area3D
{
	private bool playerNearby = false;
	private Label prompt;  //press e label

	public override void _Ready()
	{
		BodyEntered += OnBodyEntered;
		BodyExited += OnBodyExited;

		prompt = GetNode<Label>("/root/Environment/CanvasLayer/Label");  //gets label and adds to environment node
		prompt.Visible = false;  //press e label
	}

	private void OnBodyEntered(Node3D body)
	{
		if (body.Name == "Player")  //if player node enters
		{
			playerNearby = true;    //if player enters the collectible space
			prompt.Visible = true;  //shows press e label
		}
	}

	private void OnBodyExited(Node3D body)
	{
		if (body.Name == "Player")  //if player node exited
		{
			playerNearby = false;
			prompt.Visible = false;
		}
	}

	public override void _Process(double delta)
	{
		if (playerNearby && Input.IsKeyPressed(Key.E))  //if player is in collectible space AND e is pressed
		{
			prompt.Visible = false;  //stop showing press e label
			GD.Print("Collectible picked up!");  //print collectible picked up
			QueueFree();  //remove collectible from game
		}
	}
}
