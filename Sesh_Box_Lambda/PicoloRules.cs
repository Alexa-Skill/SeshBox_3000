using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Sesh_Box_Lambda
{
    class PicoloRules
    {

        string randomParticipentName = "Ciaran";
        int beverageConsumption = 5;
        Random rnd = new Random();
        public string Rules(string version)
        {
            List<string> warRules = new List<string>(new string[] {
                randomParticipentName + "  if you are a girl lick your finger in an erotic way. If you are a guy do a cunnilingus with two fingers. Or finish your drink",
                "If you've had sex in a public place drink " + beverageConsumption + "  times",
                randomParticipentName + "  pretend you are having an orgasm for  seconds or finish your drink",
                "If you've had a threesome drink " + beverageConsumption + "  times. If all three people are in the room right now drink double!",
                "Girls pull up your thongs",
                randomParticipentName + "  and  " + randomParticipentName + "  cuddle for the next 5 minutes",
                "If you've had Skype sex drink " + beverageConsumption + "  times",
                "If you've ever thought of someone else during sex drink " + beverageConsumption + "  times",
                "If you would sleep with someone else in this room right now drink " + beverageConsumption + "  times",
                "Drink " + beverageConsumption + "  times if you've had sex on the first date",
                "If you love oral drink " + beverageConsumption + "  times",
                "If you've made a sex tape drink " + beverageConsumption + "  times",
                "If you think  " + randomParticipentName + "  is a good bang drink " + beverageConsumption + "  times",
                randomParticipentName + "  get your finger sucked by  " + randomParticipentName + "  or drink " + beverageConsumption + "  times",
                "If you have given someone a rimjob drink " + beverageConsumption + "  times",
                "Everyone unbutton your shirts and drink once for each button",
                randomParticipentName + "  take an item of clothing off of  " + randomParticipentName + "  or drink " + beverageConsumption + "  times",
                "If you have ever been caught masturtating drink " + beverageConsumption + "  times",
                "If you shave your intimate areas drink " + beverageConsumption + "  times",
                " Drink " + beverageConsumption + "  times if you've visited a porn site in the last two weeks",
                "If you like dirty talk drink " + beverageConsumption + "  times",
                randomParticipentName + "  how many drinks would it take for you to sleep with  " + randomParticipentName + " ? Answer and drink " + beverageConsumption + "  times",
                randomParticipentName + "  who do you think would give the best head out of the people in the room? Answer and drink " + beverageConsumption + "  times",
                "If you've ever roleplayed to keep things spicy drink " + beverageConsumption + "  times",
                randomParticipentName + "  simulate an orgasm before every drink until told otherwise",
                randomParticipentName + "  you no longer have to simulate an orgasm before every drink",
                randomParticipentName + "  give " + beverageConsumption + "  sips to the sexiest person in the room. (Yes you are sexy but pick someone other than yourself)",
                "If you've ever slept with someone and not remembered their name drink " + beverageConsumption + "  times",
                "If you've had sex in a hotel drink " + beverageConsumption + "  times",
                randomParticipentName + "  act out doggy style for 5 seconds or drink " + beverageConsumption + "  times",
                "If you've never had sex in a car drink " + beverageConsumption + "  times",
                randomParticipentName + "  name a sexual act that you haven't done. Anybody who has done it drink " + beverageConsumption + "  times",
                "If you've ever taken a pole dancing class drink " + beverageConsumption + "  times",
                "If you've ever gotten a sex toy as a birthday present drink " + beverageConsumption + "  times",
                "If you've hooked up with anyone in the room both of you drink " + beverageConsumption + "  times",
                "If you are eskimo brothers/sisters with anyone in the room both of you drink " + beverageConsumption + "  times",
                randomParticipentName + "  if you show us one of your tits  " + randomParticipentName + "  has to drink " + beverageConsumption + "  times. If not you drink " + beverageConsumption + "  times.",
                randomParticipentName + "   " + randomParticipentName + "   " + randomParticipentName + "  and  " + randomParticipentName + " - pretend to gangbang  " + randomParticipentName + "  or drink " + beverageConsumption + "  times.",
                randomParticipentName + "  either kiss  " + randomParticipentName + " 's feet or drink " + beverageConsumption + "  times.",
                randomParticipentName + "  if you kiss  " + randomParticipentName + "  on the cheek everybody takes " + beverageConsumption + "  sips",
                "Everyone drink for the number of orgasms you've had this week including ones resulting from a self-performance.",
                "If you haven't had sex this week drink " + beverageConsumption + "  times",
                "If you've had sex with someone more than 5 years older than you drink " + beverageConsumption + "  times",
                "If you've had sex with someone more than 5 years younger than you drink " + beverageConsumption + "  times",
                "If  " + randomParticipentName + "  and  " + randomParticipentName + "  kiss each of you can give you " + beverageConsumption + "  sips. If not you each have to drink " + beverageConsumption + "  times.",
                "If you've ever sexted (sex texting) with someone drink " + beverageConsumption + "  times.",
                "The first person who can show us a text about sex can give out " + beverageConsumption + "  sips",
                "If you've ever been unable to get it up during a sexual encounter drink " + beverageConsumption + "  times.",
                "If you've had sex with another player in the room drink " + beverageConsumption + "  times",
                randomParticipentName + "  if you've had sex more than 4 times in one day give out " + beverageConsumption + "  drinks. If not drink " + beverageConsumption + "  times.",
                "If you've ever fantasized about a friend's partner drink " + beverageConsumption + "  times",
                "If you've ever sent sexual pictures to someone drink " + beverageConsumption + "  times",
                "If you've ever licked or eaten food off someone drink " + beverageConsumption + "  times.",
                "If you've ever had sex in your parent's bed drink " + beverageConsumption + "  times.",
                "If you've ever screamed out your partner's name while having sex drink " + beverageConsumption + "  times.",
                "If you've had an orgasm in less than 3 minutes drink " + beverageConsumption + "  times.",
                randomParticipentName + "  take one item of clothing off of  " + randomParticipentName + "  or drink " + beverageConsumption + "  times.",
                "If you've had sex while you or your partner was on her period drink " + beverageConsumption + "  times.",
                "Who's better in bed between  " + randomParticipentName + "  and  " + randomParticipentName + " ? The winner drinks " + beverageConsumption + "  times.",
                "If you've ever had a purely sexual relationship with a friend drink " + beverageConsumption + "  times.",
                "If your first time hurt like a motherfucker drink " + beverageConsumption + "  times",
                randomParticipentName + "  if having sex with  " + randomParticipentName + "  wouldn't bother you give out " + beverageConsumption + "  sips",
                randomParticipentName + "  if you've secretly been in love with  " + randomParticipentName + "  drink " + beverageConsumption + "  times together",
                 randomParticipentName + "  pinch  " + randomParticipentName + " 's tits or he/she drinks " + beverageConsumption + "  times",
                "If you've ever stuck an object into your partner during sex drink " + beverageConsumption + "  times.",
                "If you've every cried out the wrong person's name while having sex drink " + beverageConsumption + "  times.",
                randomParticipentName + "  choose someone and you must now stare into his/her eyes until we tell you to stop!",
                randomParticipentName + "  you can stop staring deeply into your friend's eyes!",
                "Everytime you speak you must stroke your chest!",
                "You can all stop stroking your chests! (And if you want you can start stroking someone else's just a suggestion)",
                beverageConsumption + "  times",
                "Drink " + beverageConsumption + "  times if you've ever had sex thanks to a dating website",
                "The last person to visit a porn site gives out " + beverageConsumption + "  sips",
                "The one who has had the most sex thanks to a dating website give out " + beverageConsumption + "  sips",
                "Drink " + beverageConsumption + "  times if you've ever been scratched while having sex",
                "Drink " + beverageConsumption + "  times if you've ever held a sex toy in your hands",
                "Drink " + beverageConsumption + "  times if you've ever used objects while having sex",
                "Drink " + beverageConsumption + "  times if you've ever gotten excited by a professional massage",
                randomParticipentName + "  licks  " + randomParticipentName + " 's nose or drink " + beverageConsumption + "  times",
                "Drink " + beverageConsumption + "  times if you've ever spit while going down on your partner.",
                "Drink " + beverageConsumption + "  times if you've given a blowjob this month",
                randomParticipentName + "  give a head massage to  " + randomParticipentName + "  or drink " + beverageConsumption + "  times",
                randomParticipentName + "  get your crotch sensually touched by  " + randomParticipentName + "  or drink " + beverageConsumption + "  times",
                "Drink " + beverageConsumption + "  times if you've given a blowjob this week",
                "Drink " + beverageConsumption + "  times if you've ever had an object in your anus or vagina",
                randomParticipentName + "  kiss  " + randomParticipentName + "  on the nose or drink " + beverageConsumption + "  times",
                "Drink " + beverageConsumption + "  times if you are a naughty one and have insulted your partner while having sex",
                randomParticipentName + "  chooses two people to kiss one another " + beverageConsumption + "  sips for each if one of them refuses",
                "Drink " + beverageConsumption + "  times if you've ever seen a friend cheat on their boyfriend/girlfriend",
                "Drink " + beverageConsumption + "  times if you have ever dated your friend's ex. ",
                randomParticipentName + "  if the last time you had sex you used condoms give out " + beverageConsumption + "  sips drink them otherwise",
                randomParticipentName + "  would you rather have oral anal or vaginal sex? Answer and drink " + beverageConsumption + "  times",
                "Drink " + beverageConsumption + "  times if you've ever been insulted while having sex",
                " get on all fours and arch your back until told otherwise!",
                "  can be in a comfortable position again",
                randomParticipentName + "  you're the cop! You can body-search anyone anywhere! " + beverageConsumption + " -sips penalty in case of refusal!",
                randomParticipentName + "  you're not the cop anymore you can drink " + beverageConsumption + "  times you pervert!",
                randomParticipentName + "  is Cupid! You choose who kisses or hugs who " + beverageConsumption + " -sips penalty in case of refusal",
                randomParticipentName + "  you're not Cupid anymore. ",
                " Drink " + beverageConsumption + "  times if you like being watched while you make love" });
            int index = rnd.Next(1,100);
            if (version == "war")
            {
                return warRules[index];

            }
            return "Major fucking error with the rule return";
        }
    }
}
