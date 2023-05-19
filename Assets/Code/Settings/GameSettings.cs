using UnityEngine;

namespace Code.Settings
{
    [CreateAssetMenu(fileName = nameof(GameSettings), menuName = nameof(GameSettings))]
    public sealed class GameSettings : ScriptableObject
    {
        [SerializeField] private int _enemyInLineCount;
        [SerializeField] private int _enemyLineUsedCount;
        [SerializeField] private float _enemyOffset;
        [SerializeField] private float _enemyDownStepOffset;
        [SerializeField][Range(1, 100)] private float _enemyDropBonus;

        public int EnemyInLineCount => _enemyInLineCount;
        public int EnemyLineUsedCount => _enemyLineUsedCount;
        public float EnemyOffset => _enemyOffset;
        public float EnemyDownStepOffset => _enemyDownStepOffset;
        public float EnemyDropBonus => _enemyDropBonus/100;
    }
}
