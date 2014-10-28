using System.ComponentModel;

namespace ToastmasterScheduler.Domain
{
    public enum RoleTypes
    {
        [Description("Set Up, Complete Manuals")]
        Setup = 0,

        [Description("Sergeant at Arms")]
        SergeantAtArms = 1,

        [Description("Toastmaster Introduction of Guests")]
        GuestIntroduction = 2,

        [Description("New Member Induction")]
        NewMemberInduction = 3,

        [Description("Grammarian")]
        Grammarian = 4,

        [Description("Inspiration")]
        Inspiration = 5,

        [Description("Project Speech")]
        ProjectSpeech = 6,

        [Description("Evaluator")]
        Evaluator = 7,

        [Description("Table Topics Master")]
        TableTopicsMaster = 8,

        [Description("Tonic")]
        Tonic = 9,

        [Description("Table Topics Evaluator")]
        TableTopicsEvaluator = 10,

        [Description("BREAK - PLEASE BRING SNACKS")]
        Break = 11,

        [Description("Tall Tales")]
        TallTales = 12,

        [Description("Evaluate Evaluators")]
        EvaluateEvaluators = 13,

        [Description("Timer")]
        Timer = 14,

        [Description("General Evaluation")]
        GeneralEvaluation = 15,

        [Description("Close")]
        MeetingClose = 16,
    }
}