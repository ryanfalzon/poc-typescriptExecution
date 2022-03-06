import { CompileFailedError, compileSol } from "solc-typed-ast";

var generateAst = async function (callback: (error: any, result: any) => void, filepath: string) {
    try {
        const result = await compileSol(filepath, "auto", []);

        const response = {
            success: true,
            data: JSON.stringify(result.data)
        };

        callback(null, response);
    } catch (e) {
        let errorMessage = e.Message;

        if (e instanceof CompileFailedError) {
            errorMessage = "Compile errors encountered:\n";

            for (const failure of e.failures) {
                errorMessage += `\nSolc ${failure.compilerVersion}:`;

                for (const error of failure.errors) {
                    errorMessage += `\n${error}`;
                }
            }
        }

        callback({
            success: false,
            error: errorMessage
        }, null);
    }
};

export = generateAst;