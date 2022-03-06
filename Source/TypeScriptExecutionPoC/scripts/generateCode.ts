import { ASTReader, ASTWriter, DefaultASTWriterMapping, LatestCompilerVersion, PrettyFormatter } from "solc-typed-ast";

var generateCode = async function (callback: (error: any, result: any) => void, compileResultData: any) {
    try {
        const reader = new ASTReader();
        const sourceUnits = reader.read(JSON.parse(compileResultData));

        const formatter = new PrettyFormatter(4, 0);
        const writer = new ASTWriter(
            DefaultASTWriterMapping,
            formatter,
            LatestCompilerVersion
        );

        let result = "";
        for (const sourceUnit of sourceUnits) {
            result += writer.write(sourceUnit);
        }

        callback(null, result);
    }
    catch (e) {
        callback(null, e.message);
    }
};

export = generateCode;