using System;
using System.Collections.Generic;
using BepInEx;
using UnityEngine;
using TMPro;
using Unity.Mathematics;

namespace JesusLovesYou
{
    /// <summary>
    /// This is your mod's main class.
    /// </summary>
    [BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
    public class Plugin : BaseUnityPlugin
    {
        public GameObject motdtext;
        public GameObject motdlabel;

        // now, all of the bible verses :p
        public List<string> bibleVerses = new List<string>
        {
            // Old Testament
            "The Lord bless you and keep you; the Lord make his face shine on you and be gracious to you. - Numbers 6:24-25",
            "Hear, O Israel: The Lord our God, the Lord is one. - Deuteronomy 6:4",
            "Be strong and courageous. Do not be afraid or terrified because of them, for the Lord your God goes with you. - Deuteronomy 31:6",
            "Have I not commanded you? Be strong and courageous. Do not be afraid; do not be discouraged. - Joshua 1:9",
            "But as for me and my household, we will serve the Lord. - Joshua 24:15",
            "The Lord is my rock, my fortress and my deliverer. - 2 Samuel 22:2",
            "For you created my inmost being; you knit me together in my mother's womb. - Psalm 139:13",
            "The Lord is my light and my salvation—whom shall I fear? - Psalm 27:1",
            "God is our refuge and strength, an ever-present help in trouble. - Psalm 46:1",
            "Be still, and know that I am God. - Psalm 46:10",
            "Cast your cares on the Lord and he will sustain you. - Psalm 55:22",
            "This is the day that the Lord has made; let us rejoice and be glad in it. - Psalm 118:24",
            "I lift up my eyes to the mountains—where does my help come from? My help comes from the Lord. - Psalm 121:1-2",
            "Children are a heritage from the Lord, offspring a reward from him. - Psalm 127:3",
            "How sweet are your words to my taste, sweeter than honey to my mouth! - Psalm 119:103",
            "I praise you because I am fearfully and wonderfully made. - Psalm 139:14",
            "The name of the Lord is a fortified tower; the righteous run to it and are safe. - Proverbs 18:10",
            "A friend loves at all times, and a brother is born for a time of adversity. - Proverbs 17:17",
            "Whoever walks in integrity walks securely, but whoever takes crooked paths will be found out. - Proverbs 10:9",
            "Above all else, guard your heart, for everything you do flows from it. - Proverbs 4:23",
            "A gentle answer turns away wrath, but a harsh word stirs up anger. - Proverbs 15:1",
            "Start children off on the way they should go, and even when they are old they will not turn from it. - Proverbs 22:6",
            "Where there is no vision, the people perish. - Proverbs 29:18",
            "To humans belong the plans of the heart, but from the Lord comes the proper answer of the tongue. - Proverbs 16:1",
            "Trust in the Lord with all your heart and lean not on your own understanding. - Proverbs 3:5",
            "For the eyes of the Lord range throughout the earth to strengthen those whose hearts are fully committed to him. - 2 Chronicles 16:9",
            "But you will receive power when the Holy Spirit comes on you. - Acts 1:8",
            "The Lord is good, a refuge in times of trouble. He cares for those who trust in him. - Nahum 1:7",
            "He has shown you, O mortal, what is good. And what does the Lord require of you? To act justly and to love mercy and to walk humbly with your God. - Micah 6:8",
            "The grass withers and the flowers fall, but the word of our God endures forever. - Isaiah 40:8",
            "So do not fear, for I am with you; do not be dismayed, for I am your God. - Isaiah 41:10",
            "When you pass through the waters, I will be with you; and when you pass through the rivers, they will not sweep over you. - Isaiah 43:2",
            "For my thoughts are not your thoughts, neither are your ways my ways, declares the Lord. - Isaiah 55:8",
            "Seek the Lord while he may be found; call on him while he is near. - Isaiah 55:6",
            "The Spirit of the Sovereign Lord is on me, because the Lord has anointed me to proclaim good news to the poor. - Isaiah 61:1",
            "Because of the Lord's great love we are not consumed, for his compassions never fail. They are new every morning; great is your faithfulness. - Lamentations 3:22-23",
            "And I will put my Spirit in you and move you to follow my decrees and be careful to keep my laws. - Ezekiel 36:27",
            "But let justice roll on like a river, righteousness like a never-failing stream! - Amos 5:24",
            "What does the Lord require of you? To act justly and to love mercy and to walk humbly with your God. - Micah 6:8",
            "The Lord your God is with you, the Mighty Warrior who saves. - Zephaniah 3:17",
            "'Not by might nor by power, but by my Spirit,' says the Lord Almighty. - Zechariah 4:6",

            // Gospels
            "Come to me, all you who are weary and burdened, and I will give you rest. - Matthew 11:28",
            "Therefore do not worry about tomorrow, for tomorrow will worry about itself. - Matthew 6:34",
            "For where two or three gather in my name, there am I with them. - Matthew 18:20",
            "What good will it be for someone to gain the whole world, yet forfeit their soul? - Matthew 16:26",
            "But seek first his kingdom and his righteousness, and all these things will be given to you as well. - Matthew 6:33",
            "Watch and pray so that you will not fall into temptation. - Matthew 26:41",
            "Let your light shine before others, that they may see your good deeds and glorify your Father in heaven. - Matthew 5:16",
            "Therefore everyone who hears these words of mine and puts them into practice is like a wise man who built his house on the rock. - Matthew 7:24",
            "The thief comes only to steal and kill and destroy; I have come that they may have life, and have it to the full. - John 10:10",
            "Jesus answered, 'I am the way and the truth and the life. No one comes to the Father except through me.' - John 14:6",
            "If you love me, keep my commands. - John 14:15",
            "Peace I leave with you; my peace I give you. I do not give to you as the world gives. Do not let your hearts be troubled and do not be afraid. - John 14:27",
            "I am the vine; you are the branches. If you remain in me and I in you, you will bear much fruit. - John 15:5",
            "Greater love has no one than this: to lay down one's life for one's friends. - John 15:13",
            "In this world you will have trouble. But take heart! I have overcome the world. - John 16:33",
            "Then Jesus declared, 'I am the bread of life. Whoever comes to me will never go hungry.' - John 6:35",
            "For God did not send his Son into the world to condemn the world, but to save the world through him. - John 3:17",
            "The Word became flesh and made his dwelling among us. We have seen his glory, the glory of the one and only Son. - John 1:14",
            "Repent, for the kingdom of heaven has come near. - Matthew 3:2",
            "Blessed are those who hunger and thirst for righteousness, for they will be filled. - Matthew 5:6",
            "You are the salt of the earth. - Matthew 5:13",
            "Do not store up for yourselves treasures on earth, where moths and vermin destroy. - Matthew 6:19",
            "For whoever wants to save their life will lose it, but whoever loses their life for me will find it. - Matthew 16:25",
            "Love the Lord your God with all your heart and with all your soul and with all your mind. - Matthew 22:37",
            "Love your neighbor as yourself. - Matthew 22:39",
            "Therefore go and make disciples of all nations, baptizing them in the name of the Father and of the Son and of the Holy Spirit. - Matthew 28:19",
            "The Son of Man did not come to be served, but to serve, and to give his life as a ransom for many. - Mark 10:45",
            "Whoever believes and is baptized will be saved, but whoever does not believe will be condemned. - Mark 16:16",
            "Today in the town of David a Savior has been born to you; he is the Messiah, the Lord. - Luke 2:11",
            "For the Son of Man came to seek and to save the lost. - Luke 19:10",
            "Do not be afraid, Mary; you have found favor with God. - Luke 1:30",
            "He has brought down rulers from their thrones but has lifted up the humble. - Luke 1:52",
            "And Jesus grew in wisdom and stature, and in favor with God and man. - Luke 2:52",
            "Blessed are you who are poor, for yours is the kingdom of God. - Luke 6:20",
            "Do to others as you would have them do to you. - Luke 6:31",
            "Your kingdom come, your will be done, on earth as it is in heaven. - Matthew 6:10",

            // Acts & Epistles
            "Salvation is found in no one else, for there is no other name under heaven given to mankind by which we must be saved. - Acts 4:12",
            "In him we have redemption through his blood, the forgiveness of sins, in accordance with the riches of God's grace. - Ephesians 1:7",
            "For it is by grace you have been saved, through faith—and this is not from yourselves, it is the gift of God. - Ephesians 2:8",
            "For we are God's handiwork, created in Christ Jesus to do good works. - Ephesians 2:10",
            "Be kind and compassionate to one another, forgiving each other, just as in Christ God forgave you. - Ephesians 4:32",
            "Finally, be strong in the Lord and in his mighty power. - Ephesians 6:10",
            "Rejoice in the Lord always. I will say it again: Rejoice! - Philippians 4:4",
            "Do not be anxious about anything, but in every situation, by prayer and petition, with thanksgiving, present your requests to God. - Philippians 4:6",
            "Whatever you have learned or received or heard from me, or seen in me—put it into practice. - Philippians 4:9",
            "I can do all this through him who gives me strength. - Philippians 4:13",
            "And my God will meet all your needs according to the riches of his glory in Christ Jesus. - Philippians 4:19",
            "Let the peace of Christ rule in your hearts, since as members of one body you were called to peace. - Colossians 3:15",
            "And whatever you do, whether in word or deed, do it all in the name of the Lord Jesus. - Colossians 3:17",
            "Let us not become weary in doing good, for at the proper time we will reap a harvest if we do not give up. - Galatians 6:9",
            "So in Christ Jesus you are all children of God through faith. - Galatians 3:26",
            "For the Spirit God gave us does not make us timid, but gives us power, love and self-discipline. - 2 Timothy 1:7",
            "All Scripture is God-breathed and is useful for teaching, rebuking, correcting and training in righteousness. - 2 Timothy 3:16",
            "Preach the word; be prepared in season and out of season. - 2 Timothy 4:2",
            "Fight the good fight of the faith. Take hold of the eternal life to which you were called. - 1 Timothy 6:12",
            "For the love of money is a root of all kinds of evil. - 1 Timothy 6:10",
            "If we confess our sins, he is faithful and just and will forgive us our sins and purify us from all unrighteousness. - 1 John 1:9",
            "Dear friends, let us love one another, for love comes from God. Everyone who loves has been born of God and knows God. - 1 John 4:7",
            "We love because he first loved us. - 1 John 4:19",
            "This is how we know what love is: Jesus Christ laid down his life for us. And we ought to lay down our lives for our brothers and sisters. - 1 John 3:16",
            "Do not merely listen to the word, and so deceive yourselves. Do what it says. - James 1:22",
            "Consider it pure joy, my brothers and sisters, whenever you face trials of many kinds. - James 1:2",
            "Every good and perfect gift is from above, coming down from the Father of the heavenly lights. - James 1:17",
            "Submit yourselves, then, to God. Resist the devil, and he will flee from you. - James 4:7",
            "Humble yourselves before the Lord, and he will lift you up. - James 4:10",
            "Cast all your anxiety on him because he cares for you. - 1 Peter 5:7",
            "But you are a chosen people, a royal priesthood, a holy nation, God's special possession. - 1 Peter 2:9",
            "Always be prepared to give an answer to everyone who asks you to give the reason for the hope that you have. - 1 Peter 3:15",
            "Whoever does not love does not know God, because God is love. - 1 John 4:8",
            "No one has ever seen God; but if we love one another, God lives in us and his love is made complete in us. - 1 John 4:12",
            "There is no fear in love. But perfect love drives out fear. - 1 John 4:18",
            "Dear children, let us not love with words or speech but with actions and in truth. - 1 John 3:18",
            "And we know that in all things God works for the good of those who love him. - Romans 8:28",
            "If God is for us, who can be against us? - Romans 8:31",
            "For I am convinced that neither death nor life, neither angels nor demons, neither the present nor the future, nor any powers, neither height nor depth, nor anything else in all creation, will be able to separate us from the love of God that is in Christ Jesus our Lord. - Romans 8:38-39",
            "Do not conform to the pattern of this world, but be transformed by the renewing of your mind. - Romans 12:2",
            "Be joyful in hope, patient in affliction, faithful in prayer. - Romans 12:12",
            "Bless those who persecute you; bless and do not curse. - Romans 12:14",
            "If it is possible, as far as it depends on you, live at peace with everyone. - Romans 12:18",
            "Do not be overcome by evil, but overcome evil with good. - Romans 12:21",
            "Let no debt remain outstanding, except the continuing debt to love one another. - Romans 13:8",
            "Therefore encourage one another and build each other up, just as in fact you are doing. - 1 Thessalonians 5:11",
            "Rejoice always, pray continually, give thanks in all circumstances; for this is God's will for you in Christ Jesus. - 1 Thessalonians 5:16-18",
            "May God himself, the God of peace, sanctify you through and through. - 1 Thessalonians 5:23",
            "The one who calls you is faithful, and he will do it. - 1 Thessalonians 5:24",
            "Now faith is confidence in what we hope for and assurance about what we do not see. - Hebrews 11:1",
            "Let us run with perseverance the race marked out for us, fixing our eyes on Jesus, the pioneer and perfecter of faith. - Hebrews 12:1-2",
            "Jesus Christ is the same yesterday and today and forever. - Hebrews 13:8",
            "Do not forget to show hospitality to strangers, for by so doing some people have shown hospitality to angels without knowing it. - Hebrews 13:2",
            "For the word of God is alive and active. Sharper than any double-edged sword. - Hebrews 4:12",
            "Therefore, since we have a great high priest who has ascended into heaven, Jesus the Son of God, let us hold firmly to the faith we profess. - Hebrews 4:14",
            "Let us then approach God's throne of grace with confidence, so that we may receive mercy and find grace to help us in our time of need. - Hebrews 4:16",

            // Revelation
            "I am the Alpha and the Omega, the First and the Last, the Beginning and the End. - Revelation 22:13",
            "Behold, I am coming soon! My reward is with me, and I will give to each person according to what they have done. - Revelation 22:12",
            "He who testifies to these things says, 'Yes, I am coming soon.' Amen. Come, Lord Jesus. - Revelation 22:20",
            "To the one who is victorious, I will give the right to eat from the tree of life, which is in the paradise of God. - Revelation 2:7",
            "Be faithful, even to the point of death, and I will give you life as your victor's crown. - Revelation 2:10",
            "Here I am! I stand at the door and knock. If anyone hears my voice and opens the door, I will come in and eat with that person, and they with me. - Revelation 3:20",
            "Worthy is the Lamb, who was slain, to receive power and wealth and wisdom and strength and honor and glory and praise! - Revelation 5:12",
            "They will rest from their labor, for their deeds will follow them. - Revelation 14:13",
            "He will wipe every tear from their eyes. There will be no more death or mourning or crying or pain. - Revelation 21:4",
            "The city does not need the sun or the moon to shine on it, for the glory of God gives it light, and the Lamb is its lamp. - Revelation 21:23",
            "Then the angel showed me the river of the water of life, as clear as crystal, flowing from the throne of God and of the Lamb. - Revelation 22:1",
            "No longer will there be any curse. The throne of God and of the Lamb will be in the city, and his servants will serve him. - Revelation 22:3",
            "But I say to you who are listening: Love your enemies, do good to those who hate you - Luke 6:27",
            "No weapon formed against you shall prosper, and every tongue that rises against you in judgment you shall condemn. This is the heritage of the servants of the Lord, and their righteousness is from me, says the Lord - Isaiah 54:17",
        };
        private int index;

        void Start()
        {
            //GorillaTagger.OnPlayerSpawned(OnGameInitialized);
            // realized i needed to put the references to objects here and not in the other thing
            motdtext = GameObject.Find("motdBodyText");
            motdlabel = GameObject.Find("motdHeadingText");

            index = indexget();

            //(i have no idea if its legal to do that)
            motdtext.GetComponent<PlayFabTitleDataTextDisplay>().enabled = false;

            motdtext.GetComponent<TextMeshPro>().text = bibleVerses[index];
            motdtext.GetComponent<TextMeshPro>().horizontalAlignment = HorizontalAlignmentOptions.Center;
            motdtext.GetComponent<TextMeshPro>().fontSize = 130;
            motdlabel.GetComponent<TextMeshPro>().color = Color.cyan;
            motdlabel.GetComponent<TextMeshPro>().text = "Bible Verse";
        }

        int indexget()
        {
            return UnityEngine.Random.Range(0, bibleVerses.Count);
        }

        void OnGameInitialized()
        {
            // realized i needed to put the references to objects here and not in the other thing
            motdtext = GameObject.Find("motdBodyText");
            motdlabel = GameObject.Find("motdHeadingText");

            index = indexget();

            //(i have no idea if its legal to do that)
            motdtext.GetComponent<PlayFabTitleDataTextDisplay>().enabled = false;

            motdtext.GetComponent<TextMeshPro>().text = bibleVerses[index];
            motdtext.GetComponent<TextMeshPro>().horizontalAlignment = HorizontalAlignmentOptions.Center;
            motdtext.GetComponent<TextMeshPro>().fontSize = 130;
            motdlabel.GetComponent<TextMeshPro>().color = Color.cyan;
            motdlabel.GetComponent<TextMeshPro>().text = "Bible Verse";
        }
    }
}

