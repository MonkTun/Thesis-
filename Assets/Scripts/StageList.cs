using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StageList
{
    public static Stage[] Stages { get; } =
    {
        new Stage //stage 1
        (
            new string[]
            {
                "Welcome to Thesis+.\n\nThe button on the bottom right corner is the quiz button. " +
                "It will move you to the ‘quiz’ section of the game. There are 5 levels." +
                " Make sure to read this ‘learn’ section before you move on. The button right above that is the hint button. " +
                "Always feel free to make use of hints but they are not specific to each quiz but to the general stage. " +
                "\nNow press the quiz button to review how to create a thesis statement."
            },
            new Quiz[]
            {
                new Quiz
                (
                    "What is the main purpose of a thesis statement in an essay?",
                    new string[]
                    {
                        "To summarize the main argument of the essay"
                        ,"To provide background information on the topic"
                        ,"To introduce the main topic of the essay"
                        ,"To provide a roadmap for the essay, outlining the main points to be discussed"
                    },
                    3
                ),
                new Quiz
                (
                    "Which of the following is an example of a thesis statement?",
                    new string[]
                    {
                        "In this essay, I will discuss the effects of pollution on the environment."
                        ,"Pollution is a major problem in today's society."
                        ,"The effects of pollution on the environment are numerous and serious."
                        ,"Pollution in the Pacific can be attributed to the Great Pacific Garbage Patch " +
                         "and the detrimental effects of multiple countries’ refuse and climate change policies."
                    },
                    3
                ),
                new Quiz
                (
                    "A thesis statement should:",
                    new string[]
                    {
                        "Be one sentence long"
                        ,"Be a question"
                        ,"Be written in the first person"
                        ,"Be a statement that can be argued or supported"
                    },
                    3
                ),
            },
            "Remember that a good thesis statement takes a stance and tells the reader where the argument is going."
            ),
        new Stage //stage2
        (
            new string[]
            {
                "Let’s read the sample text together, Aesop’s Fable 'The Stag and His Reflection.'",
                "A Stag, drinking from a crystal spring, saw himself mirrored in the clear water. He greatly admired the graceful arch of his antlers, but he was very much ashamed of his spindling legs.",
                "'How can it be,' he sighed, 'that I should be cursed with such legs when I have so magnificent a crown.'",
                "At that moment he scented a panther and in an instant was bounding away through the forest. " +
                "But as he ran his wide-spreading antlers caught in the branches of the trees, and soon the Panther overtook him. " +
                "Then the Stag perceived that the legs of which he was so ashamed would have saved him had it not been for the useless ornaments on his head.",
                "We often make much of the ornamental and despise the useful.",
                "https://www.read.gov/aesop/018.html",
                "We may have a prompt asking us, “Analyze the figurative language in this story.” Use a thesis statement to write your interpretation. "
            },
            new Quiz[]
            {
                new Quiz
                (
                    "Which explains what a thesis is? ",
                    new string[]
                    {
                        "It explains an interpretation and why it matters."
                        ,"It explains the content of the story and why it matters."
                        ,"It explains the context of the story and what it matters. "
                        ,"It explains an idea about the story. "
                    },
                    0
                ),
                new Quiz
                (
                    "Which of the following is correct about the best way to approach writing a thesis?",
                    new string[]
                    {
                        "annotate -> determine why it matters -> choose figurative language -> write the figurative language & meaning"
                        ,"annotate -> choose figurative language -> determine why it matters -> write the figurative language & meaning"
                        ,"annotate -> write the figurative language & meaning -> choose figurative language -> determine why it matters"
                        ,"write the figurative language & meaning -> choose figurative language -> determine why it matters -> annotate "
                    },
                    1
                ),
                new Quiz
                (
                    "Which of the following might be good figurative language to analyze from this story?",
                    new string[]
                    {
                        "The crown on the stag’s head."
                        ,"The shame about the stag’s legs."
                        ,"The panther being scented."
                        ,"The stag looking at himself in the water."
                    },
                    0
                ),
                new Quiz
                (
                    "Which of the following might be a good thesis statement for this story?",
                    new string[]
                    {
                        "In being ashamed of his legs, the stag explains his reasons for running away."
                        ,"In using the metaphors of crown and ornament for antlers, the stag shows the high value he assigns to his antlers."
                        ,"By escaping the panther, the stag demonstrates that his legs are useful. "
                        ,"Since he’s chased by the panther, the reader understands that the stag is dead by the end of the story. "
                    },
                    1 
                ),
                new Quiz
                (
                    "Why was the last answer a good thesis statement?",
                    new string[]
                    {
                        "It identified a metaphor."
                        ,"It explained the point of the story."
                        ,"It took a stance that can be disagreed with."
                        ,"It disagreed with the stag."
                    },
                    2
                )
                
            },
            "Remember that a thesis should be an insightful, new understanding of a story."
        ),
        new Stage //stage 3
        (
            new string[]
            {
                "Review for thesis statements."
            }, new Quiz[]
            {
                new Quiz
                (
                    "Which of the following would be the strongest thesis statement?",
                    new string[]
                    {
                        "In the play Macbeth, blood is a symbol of guilt because Macbeth sees " +
                        "the blood on a dagger in a hallucination right before he kills the king."
                        ,"In Macbeth, the prophecies symbolize a change in perspective " +
                         "for Macbeth and Lady Macbeth as they debate their future. "
                        ,"In Macbeth, Shakespeare’s repeated use of the motif sleep in order to " +
                         "refer to some kind of death ultimately illustrates the characters’ desire for peace. "
                        ,"In Macbeth, blood is a symbol that appears throughout " +
                         "the first two Acts, symbolizing Macbeth’s conscious decisions through his experience. "
                    },
                    2
                ),
                new Quiz
                (
                    "Why is it the strongest statement?",
                    new string[]
                    {
                        "It helps us understand the text at a deeper level. "
                        ,"It demonstrates they understand what the motif means."
                        ,"It shows something obvious about the text. "
                        ,"It unites different understandings of the text. "
                    },
                    0
                ),
                new Quiz
                (
                    "Which of the following would be the strongest thesis statement? ",
                    new string[]
                    {
                        "In the novel The Absolutely True Diary of a Part-Time Indian, " +
                        "alcoholism is a looming threat to Junior and the characters, preventing them from succeeding. "
                        ,"In the epic poem The Odyssey, Odysseus’ battle against Circe and" +
                         " the Cyclops show that he is desirable and witty. "
                        ,"In the novel The Absolutely True Diary of a Part-Time Indian, Alexie’s use of hyperbole helps to portray not only " +
                         "the humor Junior finds in situations usually not thought of as humorous, but also the dangers of taking life too seriously."
                        ,"In the Harry Potter novels, Harry is a Christ-like figure to show that love is good and will always triumph over evil. "
                    },
                    2
                ),
                new Quiz
                (
                    "What is the mistake the bad thesis statements are making? ",
                    new string[]
                    {
                        "Asserting opinion"
                        ,"Describing the text and repeating the obvious"
                        ,"Summarizing"
                        ,"Being repetitive"
                    },
                    1
                ),
                new Quiz
                (
                    "Which of the following is the strongest thesis statement?",
                    new string[]
                    {
                        "In the short story “The Valley of the Dead Air,” Gary Pak uses the metaphor " +
                        "of the stinky air quality to not only show the disconnect between land and community," +
                        " but also show how the land and spirits have the upper hand over the living people. "
                        ,"In the short story “The Valley of the Dead Air,” Gary Pak shows how the stinky air " +
                         "means something is wrong in the community. "
                        ,"In Stranger Things, the two worlds that mirror each other show that every action has a consequence. "
                        ,"In Stranger Things, the comparison made to Dungeons and Dragons displays a darker side of the world" +
                         " they live in, and how people cannot act rashly because every action has a darker meaning. "
                    },
                    0
                ),
            }, 
            "Remember that a thesis statement should be specific enough to give a roadmap of the essay while making new and interesting connections. "
        ),
        new Stage //stage 4
        (
            new string[]
            {
                "Let’s read the sample text together, the song 'We Shall Overcome.' "
                ,""
                ,"We shall overcome"
                ,"We shall overcome some day"
                ,""
                ,"CHORUS:"
                ,"Oh, deep in my heart"
                ,"I do believe"
                ,"We shall overcome some day"
                ,""
                ,"We'll walk hand in hand"
                ,"We'll walk hand in hand"
                ,"We'll walk hand in hand some day"
                ,""
                ,"CHORUS"
                ,""
                ,"We shall all be free"
                ,"We shall all be free"
                ,"We shall all be free some day"
                ,""
                ,"CHORUS"
                ,""
                ,"We are not afraid"
                ,"We are not afraid"
                ,"We are not afraid some day"
                ,""
                ,"CHORUS"
                ,""
                ,"We are not alone"
                ,"We are not alone"
                ,"We are not alone some day"
                ,""
                ,"CHORUS"
                ,""
                ,"The whole wide world around"
                ,"The whole wide world around"
                ,"The whole wide world around some day"
                ,""
                ,"CHORUS"
                ,""
                ,"We shall overcome"
                ,"We shall overcome"
                ,"We shall overcome some day"
                ,""
                ,"CHORUS"
                ,""
                ,"https://en.wikisource.org/wiki/We_Shall_Overcome_(song)"
                ,""
                
            }, new Quiz[]
            {
                new Quiz
                (
                    "What might be a possible literary device in this song?",
                    new string[]
                    {
                        "Anaphora"
                        ,"Foreshadowing"
                        ,"Rhyme"
                        ,"Alliteration"
                    },
                    3
                ),
                new Quiz
                (
                    "Which of the following would be the STRONGEST literary device to focus on for an essay?",
                    new string[]
                    {
                        "Repetition"
                        ,"Alliteration"
                        ,"Hyperbole"
                        ,"Personification"
                    },
                    0
                ),
                new Quiz
                (
                    "Which of the following might be a good thesis statement for this song? ",
                    new string[]
                    {
                        "The use of repetition explains why the singers survive."
                        ,"The use of repetition emphasizes the power of how the singers must work together consistently to overcome obstacles."
                        ,"The use of an all-inclusive “We” demonstrates the power of the group."
                        ,"The use of hyperbole shows that ideals and dreams unite the singers in their future. "
                    },
                    1
                ),
            },
            "Remember that not any literary device but one that helps us understand the story in a more complex manner will strengthen analysis. "
        ),
        new Stage //stage 5
        (
            new string[]
            {
                "Read this story, 'The Oak and the Reeds.'"
                ,"A Giant Oak stood near a brook in which grew some slender Reeds." +
                 " When the wind blew, the great Oak stood proudly upright with its hundred arms uplifted to the sky." +
                 " But the Reeds bowed low in the wind and sang a sad and mournful song."
                ,"'You have reason to complain,' said the Oak. " +
                 "'The slightest breeze that ruffles the surface of the water makes you bow your heads," +
                 " while I, the mighty Oak, stand upright and firm before the howling tempest.'"
                ,"‘Do not worry about us,’ replied the Reeds. ‘The winds do not harm us." +
                 " We bow before them and so we do not break. You, in all your pride and strength, " +
                 "have so far resisted their blows. But the end is coming.’"
                ,"As the Reeds spoke a great hurricane rushed out of the north. " +
                 "The Oak stood proudly and fought against the storm, while the yielding Reeds bowed low." +
                 " The wind redoubled in fury, and all at once the great tree fell, torn up by the roots," +
                 " and lay among the pitying Reeds."
                ,"Better to yield when it is folly to resist, than to resist stubbornly and be destroyed."
                ,""
                ,"https://www.read.gov/aesop/011.html"

            }, new Quiz[]
            {
                new Quiz
                (
                    "What is a literary device that appears in this story? ",
                    new string[]
                    {
                        "Metaphor"
                        ,"Simile"
                        ,"Diction"
                        ,"Personification"
                    },
                    3
                ),
                new Quiz
                (
                    "What is the theme of the story?",
                    new string[]
                    {
                        "Living is better than dying. "
                        ,"Being a reed is better than being a tree."
                        ,"Know when to be flexible."
                        ,"Don’t be arrogant."
                    },
                    2
                ),
                new Quiz
                (
                    "Putting the theme and the literary device together, which would be the best thesis?",
                    new string[]
                    {
                        "The personification of the plants make it so that readers can understand the main message of the story."
                        ,"The personification of the plants not only help illustrate the importance of flexibility, but also the dangers of stubbornness. "
                        ,"Being unwilling to listen is personified by the tree, while being flexible is personified by the reeds. "
                        ,"The theme of flexibility is shown through the plants’ conversation. "
                    },
                    1
                ) 
            },
            "Remember that wording (diction and syntax) matters. " +
            "Don’t just say there’s a deeper meaning, but explain what that deeper meaning is. "
        ),
        new Stage //stage 6
        (
            new string[]
            {
                "Write your own.\n\n" +
                "Let’s read this poem, 'Dog in Bed.' Time to write your own thesis statement and show it to your teacher. " +
                "Make sure you can identify some literary device/figurative language and how it creates deeper meaning in the poem. "
                ,"https://www.poetryfoundation.org/poems/56332/dog-in-bed"
                ,"\nVideo Resources on Thesis Statements:"
                ,"https://www.youtube.com/watch?v=Nx2-PcBzZjo"
                ,"https://www.youtube.com/watch?v=v1xapucKlOg"
            }, new Quiz[]
            {

            },
            "Remember, all good thesis statements (1) take a stance; (2) explain why it matters (the so what); and (3) details how to prove it. "
        ),
    };
}
