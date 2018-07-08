var webpack = require('webpack');
var HTMLWebpackPlugin = require('html-webpack-plugin');
var ExtractTextPlugin = require('extract-text-webpack-plugin');
var helpers = require('./helper');

module.exports = {
    entry:{
        polyfills: './src/polyfills',
        vendor: './src/vendor',
        app: './src/main'
    },
    resolve:{
        extensions: ['.ts', '.js']
    },

    module: {
        rules: [{
            test: /\.ts$/,
            loader: [
                'babel-loader',
                {
                    loader: 'awesome-typescript-loader',
                    options: {configFileName: helpers.root('tsconfig.json')}
                },
                'angular2-template-loader'
            ],
            exclude:[/node_modules/]
        },
        {
            test: /\.js$/,
            loader: 'babel-loader',
            exclude: [/node_modules/],
            query:{
                presets: ['es2015']
            }
        },
        {
            test: /\.html$/,
            loader:'html-loader'
        },
        {
            test:/\.(png|jpe?g|gif|svg|woff|woff2|ttf|eot|ico)$/,
            loader:'file-loader?name=assets/[name].[hash].[ext]'
        },
        {
            test: /\.css$/,
            include: helpers.root('src', 'app'),
            loader: 'raw-loader'
        }
    ]
    },
    plugins: [
        // Workaround for angular/angular#11580
        new webpack.ContextReplacementPlugin(
            // The (\\|\/) piece accounts for path separators in *nix and Windows
            /angular(\\|\/)core(\\|\/)@angular/,
            helpers.root('./src'), // location of your src
            {} // a map of your routes
        ),
        
        new webpack.optimize.CommonsChunkPlugin({
            name: ['app', 'vendor', 'polyfills']
        }),

        new HTMLWebpackPlugin({
            template: 'src/index.html'
        })
    ]
}