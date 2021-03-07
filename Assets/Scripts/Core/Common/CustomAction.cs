namespace FunnyShooter.Core {
    public delegate void CustomAction();
    public delegate void CustomAction<in T>(T args);
    public delegate void CustomAction<in T1, in T2>(T1 args1, T2 args2);
    public delegate void CustomAction<in T1, in T2, in T3>(T1 args1, T2 args2, T3 args3);
    public delegate void CustomAction<in T1, in T2, in T3, in T4>(T1 args1, T2 args2, T3 args3, T4 args4);
    public delegate void CustomAction<in T1, in T2, in T3, in T4, in T5>(T1 args1, T2 args2, T3 args3, T4 args4, T5 args5);
    public delegate void CustomAction<in T1, in T2, in T3, in T4, in T5, in T6>(T1 args1, T2 args2, T3 args3, T4 args4, T5 args5, T6 args6);
    public delegate void CustomAction<in T1, in T2, in T3, in T4, in T5, in T6, in T7>(T1 args1, T2 args2, T3 args3, T4 args4, T5 args5, T6 args6, T7 args7);
    public delegate void CustomAction<in T1, in T2, in T3, in T4, in T5, in T6, in T7, in T8>(T1 args1, T2 args2, T3 args3, T4 args4, T5 args5, T6 args6, T7 args7, T8 args8);
    public delegate void CustomAction<in T1, in T2, in T3, in T4, in T5, in T6, in T7, in T8, in T9>(T1 args1, T2 args2, T3 args3, T4 args4, T5 args5, T6 args6, T7 args7, T8 args8, T9 args9);
}