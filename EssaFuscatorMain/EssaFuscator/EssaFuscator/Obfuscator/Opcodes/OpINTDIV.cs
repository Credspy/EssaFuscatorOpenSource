﻿using EssaFuscator.Bytecode_Library.Bytecode;
using EssaFuscator.Bytecode_Library.IR;

namespace EssaFuscator.Obfuscator.Opcodes
{
    public class OpINTDIV : VOpcode
    {
        public override bool IsInstruction(Instruction instruction) =>
            instruction.OpCode == Opcode.INTDIV && instruction.B <= 255 && instruction.C <= 255;

        public override string GetObfuscated(ObfuscationContext context) =>
            "Stk[Inst[OP_A]]=Stk[Inst[OP_B]]//Stk[Inst[OP_C]];";
    }
	
    public class OpINTDIVB : VOpcode
    {
        public override bool IsInstruction(Instruction instruction) =>
            instruction.OpCode == Opcode.INTDIV && instruction.B > 255 && instruction.C <= 255;

        public override string GetObfuscated(ObfuscationContext context) =>
            "Stk[Inst[OP_A]]=Const[Inst[OP_B]]//Stk[Inst[OP_C]];";

        public override void Mutate(Instruction instruction) =>
            instruction.B -= 255;
    }
	
    public class OpINTDIVC : VOpcode
    {
        public override bool IsInstruction(Instruction instruction) =>
            instruction.OpCode == Opcode.INTDIV && instruction.B <= 255 && instruction.C > 255;

        public override string GetObfuscated(ObfuscationContext context) =>
            "Stk[Inst[OP_A]]=Stk[Inst[OP_B]]//Const[Inst[OP_C]];";

        public override void Mutate(Instruction instruction) =>
            instruction.C -= 255;
    }
	
    public class OpINTDIVBC : VOpcode
    {
        public override bool IsInstruction(Instruction instruction) =>
            instruction.OpCode == Opcode.INTDIV && instruction.B > 255 && instruction.C > 255;

        public override string GetObfuscated(ObfuscationContext context) =>
            "Stk[Inst[OP_A]]=Const[Inst[OP_B]]//Const[Inst[OP_C]];";

        public override void Mutate(Instruction instruction)
        {
            instruction.B -= 255;
            instruction.C -= 255;
        }
    }
}