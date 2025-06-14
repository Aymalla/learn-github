# GitHub Actions 

Github Actions is a continuous integration and continuous deployment (CI/CD) platform that allows you to automate your build, test, and deployment pipeline. This document provides an overview of how to set up and use GitHub Actions for your project.


## Key Concepts

- **Workflow**: A configurable automated process that runs one or more jobs. Workflows are defined in YAML files in the .github/workflows directory in a repository and can be triggered by events, manually, or on a schedule. workflows can be used to build, test, and deploy code, as well as automate other tasks like sending notifications or updating documentation. contains a series of jobs that run in a specific order or in parallel, depending on their dependencies.
- **Job**: A set of steps that execute on the same runner. Jobs can run in parallel or sequentially, depending on their dependencies.
- **Step**: A single task that is part of a job. Steps can run commands, use actions, or run scripts.
- **Action**: A reusable piece of code that can be used in workflows. Actions can be created by you or the community and can be shared across workflows. Write in JavaScript, Docker, or any other language.
- **reusable workflows**: A workflow that can be called from another workflow. This allows you to create modular workflows that can be reused across multiple repositories or workflows.
- **Runner**: A server that runs your workflows. GitHub provides hosted runners, or you can self-host your own runners.
- **Event**: An activity that triggers a workflow. Events can be GitHub events (like push, pull request, etc.), scheduled events (using cron syntax), or manual triggers.
- **Environment**: A set of variables that can be used in workflows. Environments can be used to store environment-specific variables. They can also be used to define different deployment environments, such as staging or production.
- **Secret**: A secure way to store sensitive information like API keys or tokens. Secrets are encrypted and can be accessed in workflows. (read more about [secrets](https://docs.github.com/en/actions/security-for-github-actions/security-guides/using-secrets-in-github-actions)).
- **Concurrency**: A feature that allows you to limit the number of concurrent runs of a workflow. This is useful for preventing multiple runs of the same workflow from executing at the same time.
- **Matrix**: A feature that allows you to run a job multiple times with different configurations. This is useful for testing your code against multiple versions of a language or operating system.
- **Artifact**: A file or set of files produced by a workflow run. Artifacts can be used to store build outputs, test results, or any other files generated during the workflow run.
- **Cache**: A feature that allows you to store dependencies or build outputs to speed up workflow runs. Caches can be used to store files that are expensive to download or build, such as dependencies or build artifacts.
- **Inputs**: Parameters that can be passed to a workflow or action. Inputs can be used to customize the behavior of a workflow or action.
- **Outputs**: Values that can be passed from one job to another in a workflow. Outputs can be used to share data between jobs or to pass results to subsequent steps.

## GitHub Workflow 

- Workflows are `.yml` files stored in the `.github/workflows/` directory of each repository
- GitHub treats them as part of your codebase. However, when merging branches, especially long-lived ones, it's easy to create inconsistencies or break automation
- GitHub loads the workflow defined in `the exact commit` that triggered the run. This makes workflows version-controlled, traceable, and consistent
- Rebuilding Old Branch States: it’s important to pin versions of third-party actions (e.g., actions/checkout@v4) rather than using @latest

these are the main components of a workflow file:

- **name**: The name of the workflow.
- **on**: The event that triggers the workflow. This can be a Github eventl like(workflow_dispatch:
  workflow_call, pull_request, merge_group push, etc.) or a scheduled event (cron syntax), or a manual trigger. [more on events](https://docs.github.com/en/actions/writing-workflows/choosing-when-your-workflow-runs/events-that-trigger-workflows).
- **jobs**: A collection of jobs that will run as part of the workflow. Each job can run on a different runner and can have its own set of steps.
- **concurrency**: A concurrency group that allows you to limit the number of concurrent runs of a workflow. This is useful for preventing multiple runs of the same workflow from executing at the same time.
- **steps**: A sequence of tasks that will be executed as part of the job. Each step can run a script, use an action, or run a command.
- **runs-on**: The type of runner that the job will run on. This can be a specific operating system or a specific version of a language runtime.
- **uses**: Specifies an action to run as part of a step. Actions are reusable pieces of code that can be shared across workflows.
- **with**: Specifies input parameters for the action.
- **env**: Sets environment variables for the job or step.
- **if**: A conditional statement that determines whether a step or job should run based on the result of previous steps or jobs.
- **needs**: Specifies that a job depends on the completion of another job before it can run. This is useful for controlling the order of execution of jobs in a workflow.

## Contexts variables

Contexts are a way to access information about the workflow run, the event that triggered the workflow, and the environment in which the workflow is running. Contexts can be used to access information like the repository name, the branch name, the commit SHA, and more. Contexts are accessed using the `${{ }}` syntax.

- **github:** Contains information about the workflow run, the event that triggered the workflow, and the repository.
- **env:** Contains environment variables that are set for the workflow run.
- **secrets:** Contains secrets that are set for the workflow run. Secrets are encrypted and can be accessed in workflows.
- **job:** Contains information about the current job, such as the job name and the job status.
- **runner:** Contains information about the runner that is executing the workflow, such as the runner name and the runner OS.
- **inputs:** Contains input parameters that are passed to the workflow or action.
- **steps:** Contains information about the steps that have been executed in the current job, including their status and outputs.
- **matrix:** Contains information about the matrix configuration used in the workflow.

## Triggering Workflows

Workflows can be triggered by [various events](https://docs.github.com/en/actions/writing-workflows/choosing-when-your-workflow-runs/triggering-a-workflow), such as:

- **push**: Triggered when code is pushed to a branch.
- **pull_request**: Triggered when a pull request is opened, closed, or synchronized.
- **workflow_dispatch**: Allows you to manually trigger a workflow from the GitHub UI.
- **schedule**: Allows you to run a workflow on a schedule using cron syntax.
- **repository_dispatch**: Allows you to trigger a workflow from an external event, such as a webhook.
- **workflow_run**: Allows you to trigger a workflow based on the completion of another workflow.
- **merge_group**: Allows you to trigger a workflow when a merge group is created or updated.
- **fork**: Triggered when a repository is forked.
- **release**: Triggered when a release is created, published, or deleted.
- **issues**: Triggered when an issue is opened, edited, closed, or reopened
- **label**: Triggered when a label is added, edited, or deleted.
- **milestone**: Triggered when a milestone is created, edited, or closed.
- **project**: Triggered when a project is created, edited, or deleted.
- **project_card**: Triggered when a project card is created, edited, or deleted.
- **project_column**: Triggered when a project column is created, edited, or deleted.

## Workflow Scenarios

We'll explore how GitHub Actions can automate the build and release processes by creating and experimenting with two workflows:

- ✅ Build Workflow: Triggered on: Pull requests to the main branch, Pushes to the main branch, or Manual dispatch.
- 🚀 Release Workflow: Triggered on: Pushes to the release branch.

These workflows are defined in the `.github/workflows/` directory. Through these examples, we’ll observe how workflows behave in different scenarios:

- [X] Which versions of the workflows are triggered on different events.
- [X] Types of events that trigger workflows
- [X] Conditional execution of the workflows based on the event type.
- [X] How to access secrets and environment variables securely.
- [X] Usage of reusable actions and reusable workflows for better modularity and maintainability.

We will explore various scenarios to understand how workflows behave in different situations:
- [X] Trigger workflows from main branch
- [X] Trigger workflows from pull requests
- [X] Trigger workflows from release branch
- [X] Trigger workflows from manual dispatch
- [X] Trigger workflows from old commit SHA

## Out of Scope: Caching vs Artifacts

- __Artifacts:__ Artifacts are files or sets of files produced by a workflow run. They can be used to store build outputs, test results, or any other files generated during the workflow run. Artifacts can be uploaded and downloaded using the `actions/upload-artifact` and `actions/download-artifact` actions.

- __Caching:__ Caching is a feature that allows you to store dependencies or build outputs to speed up workflow runs. Caches can be used to store files that are expensive to download or build, such as dependencies or build artifacts. Caches can be created and restored using the `actions/cache` action.
- **Caching vs Artifacts**: Caching and artifacts are both used to store files generated during a workflow run, but they serve different purposes
  - **Caching** is used to store dependencies or build outputs that can be reused in future workflow runs. Caches are typically used to speed up workflow runs by avoiding the need to download or build dependencies again. Caching shares files between workflow runs.
  - **Artifacts** are used to store files that are generated during a workflow run, such as test results or build outputs. Artifacts are typically used to share files between jobs or to download files after the workflow run is complete.


