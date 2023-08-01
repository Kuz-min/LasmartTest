const path = require('path');

module.exports = {
    entry: './ClientScripts/index.ts',
    module: {
        rules: [
            {
                test: /\.tsx?$/,
                use: 'ts-loader',
                exclude: /node_modules/,
            },
        ],
    },
    resolve: {
        extensions: ['.tsx', '.ts', '.js'],
    },
    output: {
        library: {
            name: 'LasmartTest',
            type: 'var'
        },
        filename: 'bundle.js',
        path: path.resolve(__dirname, '../LasmartTest/wwwroot/js')
    }
};