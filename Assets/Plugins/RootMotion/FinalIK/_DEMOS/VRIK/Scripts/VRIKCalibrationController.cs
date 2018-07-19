using UnityEngine;
using System.Collections;
using RootMotion.FinalIK;

namespace RootMotion.Demos
{

    public class VRIKCalibrationController : MonoBehaviour
    {

        [Tooltip("Reference to the VRIK component on the avatar.")] public VRIK ik;
		[Tooltip("The settings for VRIK calibration.")] public VRIKCalibrator.Settings settings;
        [Tooltip("The HMD.")] public Transform headTracker;
		[Tooltip("(Optional) A tracker placed anywhere on the body of the player, preferrably close to the pelvis, on the belt area.")] public Transform bodyTracker;
		[Tooltip("(Optional) A tracker or hand controller device placed anywhere on or in the player's left hand.")] public Transform leftHandTracker;
		[Tooltip("(Optional) A tracker or hand controller device placed anywhere on or in the player's right hand.")] public Transform rightHandTracker;
		[Tooltip("(Optional) A tracker placed anywhere on the ankle or toes of the player's left leg.")] public Transform leftFootTracker;
		[Tooltip("(Optional) A tracker placed anywhere on the ankle or toes of the player's right leg.")] public Transform rightFootTracker;

		void Awake()
		{
			//find an IK if one is not assigned
			if (ik == null) {
				ik = FindObjectOfType<VRIK> ();
			}

			RenamePoints ();
		}

		void RenamePoints()
		{
			headTracker.name = ik.references.head.name;
			bodyTracker.name = ik.references.pelvis.name;
			leftHandTracker.name = ik.references.leftHand.name;
			rightHandTracker.name = ik.references.rightHand.name;
			leftFootTracker.name = ik.references.leftFoot.name;
			rightFootTracker.name = ik.references.rightFoot.name;

		}
			
        void LateUpdate()
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                Calibrate();
            }
        }

        [ContextMenu("Calibrate")]
        void Calibrate() {
			VRIKCalibrator.Calibrate(ik, settings, headTracker, bodyTracker, leftHandTracker, rightHandTracker, leftFootTracker, rightFootTracker);
        }
    }
}
