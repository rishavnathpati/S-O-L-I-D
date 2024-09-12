using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CustomEditor(typeof(Player))]
    public class PlayerEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            Player player = (Player)target;

            if (GUILayout.Button("Add Required Components")) AddRequiredComponents(player);
        }

        private static void AddRequiredComponents(Player player)
        {
            if (player != null)
            {
                if (player.playerAiInteractions == null)
                    player.playerAiInteractions = player.gameObject.AddComponent<PlayerAIInteractions>();

                if (player.playerMovement == null) player.playerMovement = player.gameObject.AddComponent<PlayerMovement>();

                if (player.playerRenderer == null) player.playerRenderer = player.gameObject.AddComponent<PlayerRenderer>();

                if (player.movementInput == null) player.movementInput = player.gameObject.AddComponent<PlayerInput>();

                if (player.playerAnimations == null)
                    player.playerAnimations = player.gameObject.AddComponent<PlayerAnimations>();

                if (player.uiController == null) player.uiController = player.gameObject.AddComponent<UiController>();

                player.movementInput.OnInteractEvent += () =>
                    player.playerAiInteractions.Interact(player.playerRenderer.IsSpriteFlipped);

                Debug.Log("Required components added.");
            }
        }
    }
}