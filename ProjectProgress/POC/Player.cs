using Godot;

public partial class Player : CharacterBody3D
{
	[Export]
	public float Speed = 5.0f;  //speed of player

	[Export]
	public float JumpVelocity = 5.0f;   //players speed upwards when they jump

	[Export]
	public float Gravity = 12.0f;  //the gravity of the player when they jump

	public override void _PhysicsProcess(double delta)  //controls gravity/jumping/movement/collision
	{
		if (!IsOnFloor())   //checking if the player is NOT standing on something, ! means not
		{
			Velocity = new Vector3(              //velocity is how fast the player moves in each direction
				Velocity.X,
				Velocity.Y - Gravity * (float)delta,  //this changes the players vertical velocity
				Velocity.Z
			);
		}

		if (Input.IsKeyPressed(Key.Space) && IsOnFloor())  //this checks is the space key presses AND is player standing on the floor
		{
			Velocity = new Vector3(    //setting the jump velocity
				Velocity.X,
				JumpVelocity,
				Velocity.Z
			);
		}

		Vector3 direction = Vector3.Zero;  //creating a variable called direction
										   //then it checks the WASD keys and changes direction based on that

		if (Input.IsKeyPressed(Key.W))
			direction.Z -= 1;

		if (Input.IsKeyPressed(Key.S))
			direction.Z += 1;

		if (Input.IsKeyPressed(Key.A))
			direction.X -= 1;

		if (Input.IsKeyPressed(Key.D))
			direction.X += 1;

		direction = direction.Normalized();  //this prevents the player from moving diagonally and the speed changing to be faster

		Velocity = new Vector3(    //this is turning the directions into movement
			direction.X * Speed,   
			Velocity.Y,
			direction.Z * Speed
		);

		MoveAndSlide();  //this is for the CharacterBody3D, it moves the character using the current velocity and handles collisions
	}
}
