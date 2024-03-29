using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class SpriteColorMixerBehaviour : PlayableBehaviour
{
    Color m_DefaultColor;

    Color m_AssignedColor;

    SpriteRenderer m_TrackBinding;

    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
        m_TrackBinding = playerData as SpriteRenderer;

        if (m_TrackBinding == null)
            return;

        if (m_TrackBinding.color != m_AssignedColor)
            m_DefaultColor = m_TrackBinding.color;

        int inputCount = playable.GetInputCount ();

        Color blendedColor = Color.clear;
        float totalWeight = 0f;
        float greatestWeight = 0f;

        for (int i = 0; i < inputCount; i++)
        {
            float inputWeight = playable.GetInputWeight(i);
            ScriptPlayable<SpriteColorBehaviour> inputPlayable = (ScriptPlayable<SpriteColorBehaviour>)playable.GetInput(i);
            SpriteColorBehaviour input = inputPlayable.GetBehaviour ();
            
            blendedColor += input.color * inputWeight;
            totalWeight += inputWeight;

            if (inputWeight > greatestWeight)
            {
                greatestWeight = inputWeight;
            }
        }

        m_AssignedColor = blendedColor + m_DefaultColor * (1f - totalWeight);
        m_TrackBinding.color = m_AssignedColor;
    }
}
