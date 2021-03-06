# DotNetActivityRunner
[![Build Status](https://travis-ci.org/abbgrade/DotNetActivityRunner.svg?branch=master)](https://travis-ci.org/abbgrade/DotNetActivityRunner)

Generates an environment to execute an Azure Data Factory DotNetActivity without Azure HDInsight.

## UseCases

- You want to develop unittests for your IDotNetActivity. But don't want to use a Hadoop Cluster on Azure each time.
- You want a simple environment for debugging.

## Changelog

- [x] AzureBlobDataset
- [x] AzureTableDataset

## Usage

The library Microsoft.Azure.Management.DataFactories must be installed. You can install it easily using NuGet.

The DataFactory sources (that JSON files) of all services and tables and the pipeline have to be on the local machine. Check if the ConnectionStrings are OK. VisualStudio removes the secret parts when it downloads them.

A Source Code Example is in the [Test](./DotNetActivityRunner.Test/WizardTest.cs)