using UnityEngine;

public class TargetFactory
{
    public Target CreateTarget(string tag)
    {
        switch (tag)
        {
            case "Target":
                return new GlassTarget();
            case "Terrain":
                return new TerrainTarget();
            case "Barrel":
                return new MetalTarget();
            default: 
                return null;
        }
    }
}


public abstract class Target
{
    public abstract AudioClip GetSoundClip();
}

public class GlassTarget : Target
{
    public override AudioClip GetSoundClip()
    {
        return Resources.Load<AudioClip>("Audio/Break");
    }
}

public class TerrainTarget : Target
{
    public override AudioClip GetSoundClip()
    {
        return Resources.Load<AudioClip>("Audio/SandHit");
    }
}

public class MetalTarget : Target
{
    public override AudioClip GetSoundClip()
    {
        return Resources.Load<AudioClip>("Audio/MetalHit");
    }
}