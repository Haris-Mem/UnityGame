using UnityEngine;
using System.Collections;
using System;

namespace RpgAdv
{
    public class PlayerStats : MonoBehaviour, IMessageReceiver
    {
        public int maxLevel; 
        public int currentLevel;
        public int currentExp;
        public int[] availableLevels;

        public int ExperienceToNextLevel
        {
            get
            {
                return availableLevels[currentLevel] - currentExp;
            }
        }

        private void Awake()
        {
            availableLevels = new int[maxLevel];
            ComputeLevels(maxLevel);
        }

        private void ComputeLevels(int levelCount) // computes current level
        {
            for (int i = 0; i < levelCount; i++)
            {
                var level = i + 1;
                var levelPow = Mathf.Pow(level, 2);
                var expToLevel = Convert.ToInt32(levelPow * levelCount);
                availableLevels[i] = expToLevel;
            }
        }

        public void OnReceiveMessage(MessageType type, object sender, object msg)
        {
            if (type == MessageType.DEAD)
            {
                GainExperience((sender as Damageable).experience);
            }
        }

        public void GainExperience(int gainedExp) //used to gain experience - aka level
        {
            if (gainedExp > ExperienceToNextLevel)
            {
                var remainderExp = gainedExp - ExperienceToNextLevel;
                currentExp = 0;
                currentLevel++;
                GainExperience(remainderExp);
            }
            else if (gainedExp == ExperienceToNextLevel)
            {
                currentLevel++;
                currentExp = 0;
            }
            else
            {
                currentExp += gainedExp;
            }
        }

        public int getLevel() // gets current level
        {
            return currentLevel;
        }
    }
}
