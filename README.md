# Learn github

This repository is designed as a learning environment to explore and experiment with the features of the GitHub platform, especially GitHub Actions, to build Continuous Integration and Continuous Deployment (CI/CD) pipelines.


## Workflows

We'll explore how GitHub Actions can automate the build and release processes by creating and experimenting with two workflows:

- ✅ Build Workflow: Triggered on: Pull requests to the main branch, Pushes to the main branch, or Manual dispatch.
- 🚀 Release Workflow: Triggered on: Pushes to the release branch.

These workflows are defined in the `.github/workflows/` directory. Through these examples, we’ll observe how workflows behave in different scenarios:

- [x] Which versions of the workflows are triggered on different events.
- [x] Types of events that trigger workflows
- [x] Conditional execution of the workflows based on the event type.
- [x] How to access secrets and environment variables securely.
- [x] Usage of reusable actions and reusable workflows for better modularity and maintainability.

## Caching vs Artifacts

Caching and artifacts are both used to store files generated during a workflow run, but they serve different purposes:
- **Caching** is used to store dependencies or build outputs that can be reused in future workflow runs. Caches are typically used to speed up workflow runs by avoiding the need to download or build dependencies again. Caching shares files between workflow runs.
- **Artifacts** are used to store files that are generated during a workflow run, such as test results or build outputs. Artifacts are typically used to share files between jobs or to download files after the workflow run is complete.
