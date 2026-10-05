using Godot;
using System;

public partial class BrainProto : Control
{
	private Double brain = 0;
	private ProgressBar BrainBar;
	private Double BrainGain = 5;
	private Double BrainDrain = 15;
	// ts the brain items
	private Double StableItem = 0.10;
	private Double AdaptedItem = 0.30;
	private Double IntegratedItem = 0.50;
	private Double AbberrantItem = 0.70;
	private Double TranscendantItem = 0.90;
	private string equippedItem;
	private Label EquippedLabel;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GD.Print("Accresence Brain System Online");
		GD.Print(brain);

		if (equippedItem == "StableItem")
		{
			BrainGain = BrainGain * (1 - StableItem);
		}
		else if (equippedItem == "AdaptedItem")
		{
			BrainGain = BrainGain * (1 - AdaptedItem);
		}
		else if (equippedItem == "IntegratedItem")
		{
			BrainGain = BrainGain * (1 - IntegratedItem);
		}
		else if (equippedItem == "AbberrantItem")
		{
			BrainGain = BrainGain * (1 - AbberrantItem);
		}
		else if (equippedItem == "TranscendantItem")
		{
			BrainGain = BrainGain * (1 - TranscendantItem);
		}

		BrainBar = GetNode<ProgressBar>("BrainBar");
		BrainBar.Value = brain;
		EquippedLabel = GetNode<Label>("EquippedLabel");
		GD.Print(equippedItem);
		GD.Print(BrainGain);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		brain = Math.Max(0, brain - BrainDrain * delta);
		BrainBar.Value = brain;
		if (Input.IsActionJustPressed("feed_parasite"))
		{
			
			brain += BrainGain;
			BrainBar.Value = brain;
			GD.Print ("Parasite is being fed, Brain is now at: " + brain);
		}
		if (Input.IsKeyPressed(Key.T))
			{
				equippedItem = "TranscendantItem";
			}
			
		else if (Input.IsKeyPressed(Key.A))
		{
			equippedItem = "AdaptedItem";
		}
		
		else if (Input.IsKeyPressed(Key.I))
		{
			equippedItem = "IntegratedItem";
		}
		
		else if (Input.IsKeyPressed(Key.B))
		{
			equippedItem = "AbberrantItem";
		}
		
		else if (Input.IsKeyPressed(Key.S))
		{
			equippedItem = "StableItem";
		}
		EquippedLabel.Text = "Equipped: " + equippedItem;
	}
}
