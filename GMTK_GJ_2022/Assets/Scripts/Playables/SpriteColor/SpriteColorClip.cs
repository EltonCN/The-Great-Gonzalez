using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[Serializable]
public class SpriteColorClip : PlayableAsset, ITimelineClipAsset
{
    public SpriteColorBehaviour template = new SpriteColorBehaviour ();

    public ClipCaps clipCaps
    {
        get { return ClipCaps.Blending; }
    }

    public override Playable CreatePlayable (PlayableGraph graph, GameObject owner)
    {
        var playable = ScriptPlayable<SpriteColorBehaviour>.Create (graph, template);
        return playable;
    }
}
