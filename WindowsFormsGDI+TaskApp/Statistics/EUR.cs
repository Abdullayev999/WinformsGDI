﻿namespace WindowsFormsGDI_TaskApp.Statistics
{
    public abstract class Money{ }
    public class EUR : Money
    {
        public string ID { get; set; }
        public string NumCode { get; set; }
        public string CharCode { get; set; }
        public int Nominal { get; set; }
        public string Name { get; set; }
        public float Value { get; set; }
        public float Previous { get; set; }
    }
}
