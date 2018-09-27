var path = require('path');
var webpack = require('webpack');

module.exports = {
    entry: './Scripts/es6/main.js',
    output: {
        path: path.resolve(__dirname, './Scripts/build'),
        filename: 'main.bundle.js'
    },
    module: {
        rules: [
            {
                test: /\.js$/,
                loader: 'babel-loader',
                query: {
                    presets: ['es2015']
                }
            }
        ]
    },
    stats: {
        colors: true
    },
    devtool: 'source-map'
};