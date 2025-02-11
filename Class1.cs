
using MelonLoader;


using Harmony;

using System.Linq;

using System;

using BTD_Mod_Helper;
using BTD_Mod_Helper.Extensions;
using System.Collections.Generic;

using BTD_Mod_Helper.Api.Display;

using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Towers;
using Il2CppAssets.Scripts.Unity.Display;
using Il2CppAssets.Scripts.Unity;
using UnityEngine;
using Il2CppAssets.Scripts.Models.Effects;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Unity.Bridge;
using Il2CppAssets.Scripts.Models.TowerSets;
using Il2CppAssets.Scripts.Models.Map;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions;
using Il2CppAssets.Scripts.Models.Towers.Projectiles;
using Il2Cpp;
using Il2CppAssets.Scripts.Simulation.Towers.Behaviors;
using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Models.Bloons.Behaviors.Actions;
using Il2CppAssets.Scripts.Simulation.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using Il2CppAssets.Scripts.Models.GenericBehaviors;
using Il2CppAssets.Scripts.Simulation.Towers.Weapons;
using Il2CppAssets.Scripts.Models.Towers.Weapons;
using Il2CppAssets.Scripts.Models.Towers.TowerFilters;
using Il2CppAssets.Scripts.Simulation.Bloons;
using Il2CppAssets.Scripts.Simulation.Towers.Projectiles;
using Il2CppAssets.Scripts.Utils;
using Il2CppAssets.Scripts.Models.Bloons;
using Il2CppAssets.Scripts.Simulation.Towers.Behaviors.Abilities;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities;
using Il2CppAssets.Scripts.Models.Bloons.Behaviors;

using Il2CppAssets.Scripts.Models.Rounds;
using Il2CppAssets.Scripts.Unity.UI_New.InGame.Stats;
using Il2CppAssets.Scripts.Simulation.Map.Triggers;
using Il2CppAssets.Scripts.Simulation.Track;
using Il2CppAssets.Scripts.Simulation.Bloons.Behaviors;
using Il2CppAssets.Scripts.Unity.Map.Triggers;
using MapEvent = Il2CppAssets.Scripts.Simulation.Map.Triggers.MapEvent;
using Il2CppAssets.Scripts.Simulation.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Simulation.SMath;
using Vector2 = Il2CppAssets.Scripts.Simulation.SMath.Vector2;
using CreateEffectOnExpireModel = Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.CreateEffectOnExpireModel;
using Random = System.Random;
using static Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities.Behaviors.MorphTowerModel;
using CreateEffectOnExpire = Il2CppAssets.Scripts.Simulation.Towers.Projectiles.Behaviors.CreateEffectOnExpire;
using Il2CppAssets.Scripts.Simulation.SimulationBehaviors;
using UnityEngine.Windows;
using Il2CppAssets.Scripts.Simulation;
using Il2CppAssets.Scripts.Simulation.Towers.Behaviors.Attack;
using Il2CppAssets.Scripts.Simulation.Objects;
using static Il2CppAssets.Scripts.Models.Towers.Behaviors.ParagonTowerModel;
using Il2CppAssets.Scripts;
using static Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Quaternion = Il2CppAssets.Scripts.Simulation.SMath.Quaternion;
using Il2CppAssets.Scripts.Models.Towers.Weapons.Behaviors;
using Math = Il2CppAssets.Scripts.Simulation.SMath.Math;

using UnityEngine.Assertions;
using Il2CppAssets.Scripts.Unity.Scenes;
using TMPro;
using Il2CppAssets.Scripts.Simulation.Towers.Behaviors.Abilities.Behaviors;
using Il2CppAssets.Scripts.Simulation.Towers.Behaviors.Attack.Behaviors;
using Il2CppAssets.Scripts.Simulation.Towers.Emissions;
using Il2CppAssets.Scripts.Simulation.Towers.Weapons.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Pets;
using Il2CppAssets.Scripts.Data;
using Il2CppAssets.Scripts.Simulation.Towers.Pets;
using Il2CppAssets.Scripts.Simulation.Input;
using Vector3 = UnityEngine.Vector3;
using Il2CppAssets.Scripts.Models.Towers.Filters;

using Il2CppAssets.Scripts.Models.GeraldoItems;
using BTD_Mod_Helper.Api.Enums;
using Il2CppAssets.Scripts.Models.CorvusSpells;
using System.Diagnostics.Eventing.Reader;
using Il2CppGeom;
using Il2CppAssets.Scripts.Simulation.Artifacts;
using Il2CppAssets.Scripts.Data.Legends;
using Il2CppAssets.Scripts.Unity.UI_New.Legends;
using Il2CppAssets.Scripts.Models.Towers.Upgrades;
using Il2CppAssets.Scripts.Unity.UI_New.Popups;
using Il2CppNinjaKiwi.Common;
using Il2CppAssets.Scripts.Models.SimulationBehaviors;
using Il2CppAssets.Scripts.Data.Artifacts;
using Il2CppSystem.Collections.Generic;
using Il2CppAssets.Scripts.Models.Profile;
using Il2CppAssets.Scripts.Data.Quests.TaskBehaviors;
using Il2CppAssets.Scripts.Models.Artifacts.Behaviors;
using BTD_Mod_Helper.Api.ModOptions;
using BTD_Mod_Helper.UI.Menus;
using Il2CppAssets.Scripts.Data.ContestedTerritory;
using Il2CppAssets.Scripts.Unity.UI_New.DailyChallenge;
using static Il2CppAssets.Scripts.Unity.UI_New.Legends.RogueMap;
using Il2CppAssets.Scripts.Data.Boss;
using static MelonLoader.MelonLogger;

namespace RogueCustomizer
{

    public class RogueCustomizer : BloonsTD6Mod
    {

        public static ModSettingBool OverrideStarterKits = new ModSettingBool(false)
        {
            description = "Override hero starting kits with the below options"

        };

        public static ModSettingString FirstPartyMember = new ModSettingString("DartMonkey")
        {
        description = "The first monkey in your party"

    };
    public static ModSettingString FirstPartyMemberTiers = new ModSettingString("000")
    {
        description = "The upgrade tiers of the first monkey in your party"

    };
        public static ModSettingString SecondPartyMember = new ModSettingString("HeliPilot")
        {
            description = "The second monkey in your party"

        };
        public static ModSettingString PartyMember2Tiers = new ModSettingString("520")
        {
            description = "The upgrade tiers of the second monkey in your party"

        };
        public static ModSettingString StartingArtifact = new ModSettingString("SplodeyDarts3")
        {
            description = "Heros starting artifact, copy and paste a name from the console. The number represents the tier, 0 is common, 1 is rare, 2 is legendary."

        };

        public static ModSettingBool FastMode = new ModSettingBool(false)
        {
            description = "Skip every other round, but gain extra cash and hero xp per round"

        };
       public static ModSettingBool ForgivingLives = new ModSettingBool(false)
       {
           description = "Restore all your lives upon winning a tile"

       };
        public static ModSettingBool LotsOfChoices = new ModSettingBool(false)
        {
            description = "Get offered 20 options for loot, artifacts, and boosts"

        };
        public static ModSettingBool AllLegendary = new ModSettingBool(false)
        {
            description = "All your artifacts turn to legendary when you win a tile, if it has a legendary variant"

        };

        public static ModSettingBool MinigameMayhem = new ModSettingBool(false)
        {
            description = "Replaces all Bloon Encounters with optional minigames"

        };
     
    
        public static Il2CppSystem.Collections.Generic.Dictionary<string, ArtifactDataBase> artifacts = new Il2CppSystem.Collections.Generic.Dictionary<string, ArtifactDataBase>();

       
        
        [HarmonyLib.HarmonyPatch(typeof(RogueMap), nameof(RogueMap.CreateTile))]
        public class MiniGameMayhemAddition
        {
            [HarmonyLib.HarmonyPrefix]

            public static void Postfix(RogueMap __instance, RogueTileData tileData)
            {

             
                if (MinigameMayhem)
                {

                    if (tileData.tileType == RogueTileType.pathStandardGame)
                    {

                        tileData.tileType = RogueTileType.pathNothing;


                        var list = __instance.GetAdjacentTileDatas(tileData.coords);
                        foreach (var item in list)
                        {


                            if (item.tileType == RogueTileType.terrain)
                            {


                                item.minigameData = new RogueMiniGameData();
                                int roll = new Random().Next(0, 3);

                                if (roll == 0)
                                {
                                    item.minigameData.miniGameType = RogueMiniGameType.race;
                                    item.minigameData.goal = new int[] { 480, 300, 180 };

                                    item.tileType = RogueTileType.miniGame;
                                }
                                if (roll == 1)
                                {
                                    item.minigameData.miniGameType = RogueMiniGameType.leastCash;
                                    item.minigameData.goal = new int[] { 60000, 40000, 20000 };

                                    item.tileType = RogueTileType.miniGame;
                                }
                                if (roll == 2)
                                {
                                    item.minigameData.miniGameType = RogueMiniGameType.enduranceRace;
                                    item.minigameData.goal = new int[] { 50000, 100000, 200000 };

                                    item.tileType = RogueTileType.miniGame;
                                }

                                item.map = tileData.map;






                                break;
                            }

                        }



                    }
                    


                }



            }
        }
       
                [HarmonyLib.HarmonyPatch(typeof(InGame), nameof(InGame.RoundEnd))]
        public class FastModeBonus
        {
            [HarmonyLib.HarmonyPostfix]

            public static void Postfix(InGame __instance)
            {
                
                if (FastMode)
                {
                    InGame.instance.bridge.SetRound(InGame.instance.bridge.GetCurrentRound() + 2);

                    InGame.instance.bridge.AddCash(100 + (InGame.instance.bridge.GetCurrentRound() * 50), Simulation.CashSource.Normal);

                    foreach (TowerToSimulation tower in InGame.instance.bridge.GetAllTowers().ToList())
                    {
                        if (tower.tower.towerModel.HasBehavior<HeroModel>())
                        {
                            tower.tower.GetTowerBehavior<Hero>().AddXp(200 + InGame.instance.bridge.GetCurrentRound() * 50);
                        }
                    }

                }

                
            }

        }
        [HarmonyLib.HarmonyPatch(typeof(InGame), nameof(InGame.OnVictory))]
        public class VictoryPatch
        {
            [HarmonyLib.HarmonyPostfix]

            public static void Postfix(InGame __instance)
            {
                
                
                if (ForgivingLives)
                {
                    InGame.instance.RogueSaveData.maxLives = 500;
                    InGame.instance.RogueSaveData.lives = 500;
                }
                if (LotsOfChoices)
                {
                   
                    InGame.instance.RogueSaveData.lootChoices = 20;
                    InGame.instance.RogueSaveData.endOfGameRerolls = 20;
                }

                if (AllLegendary)
                {
                    foreach (var r in InGame.instance.RogueSaveData.artifactsInventory)
                    {

                        if (artifacts.ContainsKey(r.baseId + "3") && r.tier < 2)
                        {
                            r.tier = 2;
                            r.artifactName = r.baseId + "3";
                        }
                        else if (artifacts.ContainsKey(r.baseId + "2") && r.tier < 1)
                        {
                            r.tier = 1;
                            r.artifactName = r.baseId + "2";
                        }

                        if (r.baseId == "SplodyDarts")
                        {
                            r.tier = 2;
                            r.artifactName = "SplodeyDarts3";
                        }

                    }
                }
            }

        }

                [HarmonyLib.HarmonyPatch(typeof(TitleScreen), nameof(TitleScreen.Start))]
        public class  TitleScreenPatch
        {
            [HarmonyLib.HarmonyPostfix]

            public static void Postfix()
            {

                
                foreach (var item in GameData.Instance.rogueData.rogueTileAssetData)
                {
                    MelonLogger.Msg(item.id);
                }

                FirstPartyMember.requiresRestart = true;
                SecondPartyMember.requiresRestart = true;
                StartingArtifact.requiresRestart = true;
                
                artifacts = GameData.Instance.artifactsData.artifactDatas;
         
                MelonLogger.Msg("Artifact Names:");
                foreach (var up in artifacts)
                {
                 MelonLogger.Msg(up.Key);
        
                 
                }
                
                
                if (OverrideStarterKits)
                {

                    foreach (var r in GameData.Instance.rogueData.rogueHeroStarterKits)
                    {
                        string name = FirstPartyMemberTiers;


                        r.startingInstas[0].baseId = FirstPartyMember;
                        r.startingInstas[0].tiers = new int[] { int.Parse(name.ElementAt(0) + ""), int.Parse(name.ElementAt(1) + ""), int.Parse(name.ElementAt(2) + "") };


                        string name2 = PartyMember2Tiers;


                        r.startingInstas[1].baseId = SecondPartyMember;
                        r.startingInstas[1].tiers = new int[] { int.Parse(name2.ElementAt(0) + ""), int.Parse(name2.ElementAt(1) + ""), int.Parse(name2.ElementAt(2) + "") };


                        r.artifactData.name = StartingArtifact;
                    }
                }
            }
        }
        public static int[] ParseTiers(string num)
        {
            int[] o = new int[3];
            for(int i = 0; i < 3; i++)
            {
                o[i] = int.Parse(num[i].ToString());
            }
            return o;
        }



        


    }
}
